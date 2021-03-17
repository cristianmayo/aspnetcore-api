using AspNetCore.API.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCore.API.Infrastructure.Database;
using AspNetCore.API.Infrastructure.Helpers;

namespace AspNetCore.API.Infrastructure.Services
{
    public interface IApplicationUserService
    {
        Task<bool> IsValidUsernameAsync(string userName);
        Task<bool> IsAuthorizedUserAsync(Guid userId);
        Task<bool> IsValidUserCredentialsAsync(Guid userId, string password);
        Task<IEnumerable<ApplicationUser>> GetAllApplicationUsersAsync();
        Task<ApplicationUser> GetApplicationUserByUserIdAsync(Guid userId);
        Task<ApplicationUser> GetApplicationUserByUserNameAsync(string userName);
    }

    public class ApplicationUserService : IApplicationUserService
    {
        private readonly SqlServerDbContext _context;
        public ApplicationUserService(SqlServerDbContext context)
        {
            _context = context;
        }

        public async Task<bool> IsValidUsernameAsync(string userName)
            => (await GetApplicationUserByUserNameAsync(userName)) != null;

        public async Task<bool> IsAuthorizedUserAsync(Guid userId)
            => (await GetApplicationUserByUserIdAsync(userId)) != null;

        public async Task<bool> IsValidUserCredentialsAsync(Guid userId, string password)
        {
            var appUser = await GetApplicationUserByUserIdAsync(userId);

            if(appUser == null) {
                // TODO: Error Logging
                return false;
            }

            var decryptedLoginPassword = password.Decrypt();
            var decryptedUserPassword = appUser.Password.Decrypt();
            if(!decryptedLoginPassword.Equals(decryptedUserPassword)) {
                // TODO: Error Logging
                return false;
            }

            return true;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllApplicationUsersAsync()
            => await _context.ApplicationUsers.ToListAsync();

        public async Task<ApplicationUser> GetApplicationUserByUserIdAsync(Guid userId)
            => await _context.ApplicationUsers.FirstOrDefaultAsync(user => user.UserId == userId);

        public async Task<ApplicationUser> GetApplicationUserByUserNameAsync(string userName)
            => await _context.ApplicationUsers.FirstOrDefaultAsync(user => user.UserName.Equals(userName));
    }
}
