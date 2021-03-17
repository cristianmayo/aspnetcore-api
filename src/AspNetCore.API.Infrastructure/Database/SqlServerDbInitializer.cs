using AspNetCore.API.Core.Enumerations;
using AspNetCore.API.Core.Models;
using AspNetCore.API.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.API.Infrastructure.Database
{
    public static class SqlServerDbInitializer
    {
        public static async Task InitializeData(SqlServerDbContext _context)
        {
            await _context.Database.EnsureCreatedAsync();

            if(!_context.ClientApplications.Any()) {
                var clientAppList = new List<ClientApplication>() {
                    new ClientApplication {
                        ClientId = Guid.Parse("5cbe9174-2a9c-4299-8690-21ba452b6805"),
                        Description = "Administration Portal",
                        ApplicationType = ClientApplicationType.Web.ToString(),
                        IsEnabled = true
                    }
                };

                await _context.ClientApplications.AddRangeAsync(clientAppList);
                await _context.SaveChangesAsync();
            }

            if(!_context.ApplicationRoles.Any()) {
                var applicationRoles = new List<ApplicationRole> {
                    new ApplicationRole {
                        Name = nameof(ApplicationRoleDesignation.SystemAdministrator),
                        Description = nameof(ApplicationRoleDesignation.SystemAdministrator)
                    },
                    new ApplicationRole {
                        Name = nameof(ApplicationRoleDesignation.Administrator),
                        Description = nameof(ApplicationRoleDesignation.Administrator)
                    },
                    new ApplicationRole {
                        Name = nameof(ApplicationRoleDesignation.User),
                        Description = nameof(ApplicationRoleDesignation.User)
                    }
                };

                await _context.ApplicationRoles.AddRangeAsync(applicationRoles);
                await _context.SaveChangesAsync();
            }

            if(!_context.ApplicationUsers.Any()) {
                var systemAdminUser = new ApplicationUser {
                    UserId = Guid.Parse("0e1dd76a-998e-4885-9431-8cc3f3e3f61f"),
                    UserName = "sysadmin",
                    Password = "P@ssw0rd".Encrypt(),
                    FirstName = "System",
                    LastName = "Administrator",
                    EmailAddress = "systemadmin@fdt-hris.net",
                    PhoneNumber = "09876543210"
                };

                await _context.ApplicationUsers.AddAsync(systemAdminUser);
                await _context.SaveChangesAsync();
            }

            if(!_context.UserRolePermissions.Any()) {

                var systemAdminUser = await _context.ApplicationUsers
                    .FirstOrDefaultAsync(x => x.UserName.Equals("sysadmin"));

                var systemAdminRole = await _context.ApplicationRoles
                    .FirstOrDefaultAsync(x => x.Name.Equals(nameof(ApplicationRoleDesignation.SystemAdministrator)));

                if(systemAdminUser != null && systemAdminRole != null) {

                    await _context.UserRolePermissions.AddAsync(new UserRolePermission {
                        User = systemAdminUser,
                        Role = systemAdminRole,
                        IsSystemAdministrator = true,
                        IsAdministratorOnly = false,
                        IsUserOnly = false,
                        AllowDisplay = true,
                        AllowCreate = true,
                        AllowChange = true,
                        AllowDelete = true
                    });

                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
