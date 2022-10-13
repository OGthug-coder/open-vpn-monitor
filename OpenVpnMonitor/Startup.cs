using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using OpenVpnMonitor.DataAccess;
using OpenVpnMonitor.DataAccess.Repositories;
using OpenVpnMonitor.Domain.Repositories;
using OpenVpnMonitor.Services.StatsService;
using OpenVpnMonitor.Services.VpnUserService;

namespace OpenVpnMonitor
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSwaggerGen();
            
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "client-app/build";
            });

            services.AddDbContext<ApplicationDbContext>(builder => builder.UseNpgsql(
                _configuration.GetConnectionString("DefaultConnection"),
                optionsBuilder => optionsBuilder.MigrationsAssembly("OpenVpnMonitor")));

            services.AddTransient<IVpnUserRepository, VpnUserRepository>();
            services.AddTransient<IRecordRepository, RecordRepository>();
                
            services.AddTransient<IVpnUserService, VpnUserService>();
            services.AddTransient<IStatsService, StatsService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
            
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "client-app";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
