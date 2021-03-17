using AspNetCore.API.Infrastructure.Database;
using AspNetCore.API.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCore.API.Infrastructure
{
    public static class InfrastructureServiceExtension
    {
        public static void ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IApplicationUserService, ApplicationUserService>();
            services.AddScoped<IClientApplicationService, ClientApplicationService>();
            services.AddScoped<IClientUserSessionService, ClientUserSessionService>();
            services.AddScoped<ITokenService, TokenService>();
        }

        public static void ConfigureInfrastructureDatabase(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<SqlServerDbContext>(
                options => options.UseSqlServer(config.GetConnectionString("DefaultConnection"))
            );

            services.AddDatabaseDeveloperPageExceptionFilter();
        }

    }
}
