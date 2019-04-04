using XLogger.Adapters.Console;
using Microsoft.Extensions.DependencyInjection;

namespace XLogger
{
    public static class ConsoleLoggerHubExtensions
    {
        public static ILoggerHub AddConsole(this ILoggerHub hub)
        {
            var logger = new ConsoleLogger();
            hub.Services.AddSingleton<IConsoleLogger>(logger);
            return hub.AddLogger(logger);
        }

        //TODO: Create extension method to add Console adapter with your settings
    }
}