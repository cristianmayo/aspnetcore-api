using AspNetCore.API.Core.Models;
using AspNetCore.API.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AspNetCore.API.Infrastructure.Services
{
    public interface IClientApplicationService
    {
        Task<bool> IsAuthorizedClient(Guid clientId);
        Task<ClientApplication> GetApplicationClientById(Guid clientId);
    }

    public class ClientApplicationService : IClientApplicationService
    {
        private readonly SqlServerDbContext _context;
        public ClientApplicationService(SqlServerDbContext context)
        {
            _context = context;
        }

        public async Task<bool> IsAuthorizedClient(Guid clientId)
            => (await GetApplicationClientById(clientId)) != null;

        public async Task<ClientApplication> GetApplicationClientById(Guid clientId)
        {
            var client = await _context.ClientApplications
                .FirstOrDefaultAsync(c => c.ClientId == clientId);

            return client;
        }
    }
}
