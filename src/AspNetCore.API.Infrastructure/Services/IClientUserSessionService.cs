using AspNetCore.API.Core.Models;
using AspNetCore.API.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.API.Infrastructure.Services
{
    public interface IClientUserSessionService
    {
        Task<IEnumerable<ClientUserSession>> GetAllSessionsAsync();
        Task<IEnumerable<ClientUserSession>> GetAllClientUserSessionsAsync(Guid clientId, Guid userId);
        Task<ClientUserSession> GetClientUserSessionAsync(Guid clientId, Guid userId);
        Task<ClientUserSession> SetClientUserSessionAsync(Guid clientId, Guid userId);
        Task ClearClientUserSessionAsync(Guid clientId, Guid userId);
        Task<bool> HaveMiltipleClientUserSessionAsync(Guid clientId, Guid userId);
    }

    public class ClientUserSessionService : IClientUserSessionService
    {
        private readonly SqlServerDbContext _context;
        private readonly IClientApplicationService _clientService;
        private readonly IApplicationUserService _userService;
        private readonly ITokenService _tokenService;

        public ClientUserSessionService(
            SqlServerDbContext context,
            IClientApplicationService clientService,
            IApplicationUserService userService,
            ITokenService tokenService
        )
        {
            _context = context;
            _clientService = clientService;
            _userService = userService;
            _tokenService = tokenService;
        }

        public async Task<IEnumerable<ClientUserSession>> GetAllSessionsAsync()
        => await _context.ClientUserSessions.ToListAsync();

        public async Task<IEnumerable<ClientUserSession>> GetAllClientUserSessionsAsync(Guid clientId, Guid userId)
        => await _context.ClientUserSessions
            .Where(session => session.Client.ClientId == clientId && session.User.UserId == userId)
            .ToListAsync();

        public async Task<ClientUserSession> GetClientUserSessionAsync(Guid clientId, Guid userId)
        {
            var clientUserSession = await _context.ClientUserSessions.FirstOrDefaultAsync(
                session => session.Client.ClientId == clientId
                        && session.User.UserId == userId
            );

            return clientUserSession;
        }

        public async Task<ClientUserSession> SetClientUserSessionAsync(Guid clientId, Guid userId)
        {
            var activeSession = await GetClientUserSessionAsync(clientId, userId);

            if(activeSession != null) {
                // if the access expiration have not come passed based on current date and time
                // return the active session, otherwise, proceed to updating the session with new access token and access expiration
                if(!string.IsNullOrWhiteSpace(activeSession.AccessToken) && activeSession.AccessExpiration > DateTime.UtcNow) {
                    return activeSession;
                }

                return await UpdateClientUserSessionAsync(clientId, userId);
            }

            return await NewClientUserSession(clientId, userId);
        }

        public async Task ClearClientUserSessionAsync(Guid clientId, Guid userId)
        {
            var activeSession = await GetClientUserSessionAsync(clientId, userId);

            if(activeSession != null) {

                activeSession.IsActive = false;
                activeSession.AccessToken = null;
                activeSession.AccessExpiration = null;

                _context.ClientUserSessions.Update(activeSession);

                await _context.SaveChangesAsync();
            }
        }
        public async Task<bool> HaveMiltipleClientUserSessionAsync(Guid clientId, Guid userId)
        {
            var allClientUserSessions = await GetAllClientUserSessionsAsync(clientId, userId);
            var activeSessionCount = allClientUserSessions.Count(session => session.IsActive);

            if(activeSessionCount > 1) {
                return true;
            }

            return false;
        }

        private async Task<ClientUserSession> UpdateClientUserSessionAsync(Guid clientId, Guid userId)
        {
            var session = await GetClientUserSessionAsync(clientId, userId);

            session.AccessToken = await _tokenService.CreateTokenAsync(userId.ToString());
            session.AccessExpiration = DateTime.UtcNow.AddDays(1);

            _context.ClientUserSessions.Update(session);

            await _context.SaveChangesAsync();

            return session;

        }

        private async Task<ClientUserSession> NewClientUserSession(Guid clientId, Guid userId)
        {
            var client = await _clientService.GetApplicationClientById(clientId);
            var user = await _userService.GetApplicationUserByUserIdAsync(userId);
            var newToken = await _tokenService.CreateTokenAsync(userId.ToString());
            var newSession = new ClientUserSession() {
                Client = client,
                User = user,
                IsActive = true,
                AccessToken = newToken,
                AccessExpiration = DateTime.UtcNow.AddDays(1)
            };

            await _context.ClientUserSessions.AddAsync(newSession);
            await _context.SaveChangesAsync();

            return newSession;
        }
    }
}
