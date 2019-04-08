using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using XLogger.Options;

namespace XLogger.Adapters.Console
{
    public class ConsoleLoggerOptions : LoggerOptions
    {
        //TODO: Implement OutputFormat option
        //public string OutputFormat { get; set; }

        public override void ReadFromConfiguration(IConfiguration configuration)
        {
            var consoleConfiguration = configuration.GetSection("XLogger:Console");
            this.LogLevel = (LogLevel)int.Parse(consoleConfiguration[nameof(LogLevel)]);
            this.OnDemand = bool.Parse(consoleConfiguration[nameof(OnDemand)]);
            this.DateTimeFormat = consoleConfiguration[nameof(DateTimeFormat)];
        }
    }
}