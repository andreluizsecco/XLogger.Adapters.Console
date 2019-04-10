using XLogger.Adapters.Console;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace XLogger
{
    public static class ConsoleLoggerHubExtensions
    {
        /// <summary>
        /// Adds the console logger to logger hub.
        /// </summary>
        /// <param name="hub">logger hub instance.</param>
        /// <param name="logger">console logger instance.</param>
        /// <returns>The logger hub.</returns>
        private static ILoggerHub AddConsole(ILoggerHub hub, IConsoleLogger logger)
        {
            hub.Services.AddSingleton<IConsoleLogger>(logger);
            return hub.AddLogger(logger);
        }

        /// <summary>
        /// Adds the new console logger with default options to logger hub.
        /// </summary>
        /// <param name="hub">logger hub instance.</param>
        /// <returns>The logger hub.</returns>
        public static ILoggerHub AddConsole(this ILoggerHub hub)
        {
            var options = new ConsoleLoggerOptions();
            options.ReadFromConfiguration(hub.Configuration);
            return AddConsole(hub, new ConsoleLogger(options));
        }

        /// <summary>
        /// Adds the new console logger with custom options to logger hub.
        /// </summary>
        /// <param name="hub">logger hub instance.</param>
        /// <param name="options">console logger options.</param>
        /// <returns>The logger hub.</returns>
        public static ILoggerHub AddConsole(this ILoggerHub hub, Action<ConsoleLoggerOptions> options) =>
            AddConsole(hub, new ConsoleLogger(options));
    }
}