using CoinKeeper.DataAccess.Database;
using Microsoft.EntityFrameworkCore;

namespace OpenVpnMonitor.WorkerService
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbContext<ApplicationDbContext>(options =>
                    {
                        options.UseNpgsql(hostContext.Configuration.GetConnectionString("DefaultConnection"),
                            optionsBuilder =>
                            {
                                optionsBuilder.MigrationsAssembly("OpenVpnMonitor.WorkerService");
                            });
                    });
                    services.AddHostedService<Worker>();
                });
        }
}
