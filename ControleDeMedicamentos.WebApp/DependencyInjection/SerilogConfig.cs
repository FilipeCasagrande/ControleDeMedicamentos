using Serilog;
using Serilog.Events;

namespace ControleDeMedicamentos.WebApp.DependencyInjection
{
    public static class SerilogConfig
    {
        public static void AddSerilogConfig(this IServiceCollection services, ILoggingBuilder logging, IConfiguration configuration)
        {
            var caminhoAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            var caminhoArquivoLog = Path.Combine(caminhoAppData, "ControleDeMedicamentos", "erro.log");

            var licenseKey = configuration["NEWRELIC_LICENSE_KEY"];

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File(caminhoArquivoLog, LogEventLevel.Error)
                .WriteTo.NewRelicLogs(
                endpointUrl: "https://log-api.newrelic.com/log/v1",
                applicationName: "ControleDeMedicamentos",
                licenseKey: licenseKey
                )
                .CreateLogger();

            logging.ClearProviders();

            services.AddSerilog();
        }
    }
}
