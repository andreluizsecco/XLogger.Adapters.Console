using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using XLogger.Options;

namespace XLogger.Adapters.Console
{
    public class ConsoleLoggerOptions : LoggerOptions
    {
        /// <summary>
        /// Format of the output message on the console.
        /// </summary>
        public string OutputFormat { get; set; }

        /// <summary>
        /// Construct a <see cref="ConsoleLoggerOptions"/>.
        /// By default, the <see cref="OutputFormat"/> property is set to '{@DateTime} [{@LogLevel}] {@Data} {@Exception}'.
        /// </summary>
        public ConsoleLoggerOptions() : base() =>
            OutputFormat = @"{@DateTime} [{@LogLevel}] {@Data} {@Exception}";

        /// <summary>
        /// Set the console logger options based on the key/value application configuration properties.
        /// </summary>
        /// <param name="configuration">Represents a set of key/value application configuration properties. See <see cref="IConfiguration"/>.</param>
        public override void ReadFromConfiguration(IConfiguration configuration)
        {
            var consoleConfiguration = configuration.GetSection("XLogger:Console");
            
            var logLevel = consoleConfiguration[nameof(LogLevel)];
            if (!string.IsNullOrEmpty(logLevel))
                LogLevel = (LogLevel)int.Parse(logLevel);
            OnDemand = bool.Parse(consoleConfiguration[nameof(OnDemand)] ?? OnDemand.ToString());
            OutputFormat = consoleConfiguration[nameof(OutputFormat)] ?? OutputFormat;
        }
    }
}