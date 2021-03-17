using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AspNetCore.API.Infrastructure;

namespace AspNetCore.API
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(options => options.UseMemberCasing())
                .ConfigureApiBehaviorOptions(options => options.SuppressMapClientErrors = true);

            services.AddRouting(options => options.LowercaseUrls = true);

            services.ConfigureInfrastructureServices(_config);
            services.ConfigureInfrastructureDatabase(_config);

            services.AddSwaggerDocument(doc => {
                doc.Title = _config.GetSection("WebServiceInfo:Name").Value;
                doc.Description = _config.GetSection("WebServiceInfo:Description").Value;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseOpenApi();
                app.UseSwaggerUi3();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
