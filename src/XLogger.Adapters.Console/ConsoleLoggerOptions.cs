using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using XLogger.Options;

namespace XLogger.Adapters.Console
{
    public class ConsoleLoggerOptions : LoggerOptions
    {
        public string OutputFormat { get; set; }

        public ConsoleLoggerOptions() : base() =>
            OutputFormat = @"{@DateTime} [{@LogLevel}] {@Data} {@Exception}";

        public override void ReadFromConfiguration(IConfiguration configuration)
        {
            var consoleConfiguration = configuration.GetSection("XLogger:Console");
            
            var logLevel = consoleConfiguration[nameof(LogLevel)];
            if (!string.IsNullOrEmpty(logLevel))
                this.LogLevel = (LogLevel)int.Parse(logLevel);
            this.OnDemand = bool.Parse(consoleConfiguration[nameof(OnDemand)] ?? this.OnDemand.ToString());
            this.OutputFormat = consoleConfiguration[nameof(OutputFormat)] ?? this.OutputFormat;
        }
    }
}