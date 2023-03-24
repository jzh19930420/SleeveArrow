using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

namespace SleeveArrow.Logger
{
    public static class LoggerBuilder
    {
        public static IHostBuilder UseSerilog(this IHostBuilder hostBuilder, string appName = "Application")
        {
            hostBuilder.ConfigureLogging((context, logging) =>
            {
                var logConfig = context.Configuration.GetValue<LoggerConfig>(nameof(LoggerConfig));

                var loggerOutputTemplate = "{NewLine}时间:{Timestamp:yyyy-MM-dd HH:mm:ss.fff}{NewLine}日志等级:{Level}{NewLine}所在类:{SourceContext}{NewLine}日志信息:{Message}{NewLine}{Exception}";
                Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Debug()
                        .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                        .Enrich.WithProperty("Application", appName)
                        .Enrich.FromLogContext()
                        .WriteTo.File(Path.Combine(logConfig?.SaveDirectory ?? AppDomain.CurrentDomain.BaseDirectory, "Logs", $"{appName}.txt"), rollingInterval: RollingInterval.Day, outputTemplate:loggerOutputTemplate)
#if DEBUG
                        .WriteTo.Async(d => d.Console(theme: AnsiConsoleTheme.Sixteen, outputTemplate: loggerOutputTemplate))
#endif
                        .CreateLogger();

                logging.Services.AddLogging(d => d.AddSerilog());
            });                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   

            return hostBuilder;
        }
    }
}