using OpenVpnMonitor.Metrics;
using Prometheus;

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
            services.AddTransient<IOpenVpnMonitorMetrics, OpenVpnMonitorMetrics>();
            services.AddControllers();
            services.AddWorkerService();
            services.AddMetricServer(options => { });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(builder =>
            {
                builder.MapMetrics();
            });
            
        }
    }
}
