using XLogger.Adapters.Console;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace XLogger
{
    public static class ConsoleLoggerHubExtensions
    {
        private static ILoggerHub AddConsole(ILoggerHub hub, IConsoleLogger logger)
        {
            hub.Services.AddSingleton<IConsoleLogger>(logger);
            return hub.AddLogger(logger);
        }

        public static ILoggerHub AddConsole(this ILoggerHub hub) =>
            AddConsole(hub, new ConsoleLogger());

        public static ILoggerHub AddConsole(this ILoggerHub hub, Action<ConsoleLoggerOptions> options) =>
            AddConsole(hub, new ConsoleLogger(options));
    }
}