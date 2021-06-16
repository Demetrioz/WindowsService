using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventLog;
using System.Threading.Tasks;

namespace WindowsService
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging((logBuilder) =>
                {
                    logBuilder.AddFilter<EventLogLoggerProvider>(level =>
                        level >= LogLevel.Information);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>()
                        .Configure<EventLogSettings>((config) =>
                        {
                            config.LogName = "Windows Test Service";
                            config.SourceName = "Windows Test Service";
                        });
                })
                .UseWindowsService();
    }
}
