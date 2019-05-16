using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using XLogger.Options;

namespace XLogger.Adapters.Console
{
    public class ConsoleLogger : IConsoleLogger
    {
        /// <summary>
        /// The current logger options.
        /// </summary>
        public ILoggerOptions Options { get; }

        public ConsoleLogger() =>
            Options = new ConsoleLoggerOptions();

        public ConsoleLogger(ConsoleLoggerOptions options) =>
            Options = options;

        public ConsoleLogger(Action<ConsoleLoggerOptions> options) : this() =>
            options.Invoke((ConsoleLoggerOptions)Options);

        public IDisposable BeginScope<TData>(TData data) => null;

        /// <summary>
        /// Writes a log entry.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="logLevel">Entry will be written on this level.</param>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        public void Write<TData>(LogLevel logLevel, TData data, Exception exception = null, Func<TData, Exception, object> formatter = null)
        {
            if (formatter != null)
                System.Console.WriteLine(formatter.Invoke(data, exception));
            else
                System.Console.WriteLine(Helpers.ConsoleHelper.FormatOutput((Options as ConsoleLoggerOptions).OutputFormat, logLevel, data, exception));
        }

        /// <summary>
        /// Writes a log entry.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="logLevel">Entry will be written on this level.</param>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        public async Task WriteAsync<TData>(LogLevel logLevel, TData data, Exception exception = null, Func<TData, Exception, object> formatter = null)
        {
            await Task.Run(() =>  
            {  
                if (formatter != null)
                    System.Console.WriteLine(formatter.Invoke(data, exception));
                else
                    System.Console.WriteLine(Helpers.ConsoleHelper.FormatOutput((Options as ConsoleLoggerOptions).OutputFormat, logLevel, data, exception));
            });
        }

        /// <summary>
        /// Writes a log entry.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="logLevel">Entry will be written on this level.</param>
        /// <param name="eventId">Id of the event.</param>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a string message of the data and exception.</param>
        public void Write<TData>(LogLevel logLevel, EventId eventId, TData data, Exception exception, Func<TData, Exception, string> formatter)
        {
            if (formatter != null)
                Write(logLevel, formatter(data, exception), exception);
            else
                Write(logLevel, data, exception);
        }

        /// <summary>
        /// Writes a log entry on trace level.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        public void Trace<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null) =>
            Write(LogLevel.Trace, data, exception, formatter);

        /// <summary>
        /// Writes a log entry on trace level.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        public async Task TraceAsync<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null) =>
            await WriteAsync(LogLevel.Trace, data, exception, formatter);

        /// <summary>
        /// Writes a log entry on debug level.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        public void Debug<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null) =>
            Write(LogLevel.Debug, data, exception, formatter);

        /// <summary>
        /// Writes a log entry on debug level.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        public async Task DebugAsync<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null) =>
            await WriteAsync(LogLevel.Debug, data, exception, formatter);

        /// <summary>
        /// Writes a log entry on information level.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        public void Information<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null) =>
            Write(LogLevel.Information, data, exception, formatter);

         /// <summary>
        /// Writes a log entry on information level.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        public async Task InformationAsync<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null) =>
            await WriteAsync(LogLevel.Information, data, exception, formatter);

        /// <summary>
        /// Writes a log entry on warning level.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        public void Warning<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null) =>
            Write(LogLevel.Warning, data, exception, formatter);

        /// <summary>
        /// Writes a log entry on warning level.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        public async Task WarningAsync<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null) =>
            await WriteAsync(LogLevel.Warning, data, exception, formatter);

        /// <summary>
        /// Writes a log entry on error level.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        public void Error<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null) =>
            Write(LogLevel.Error, data, exception, formatter);

        /// <summary>
        /// Writes a log entry on error level.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        public async Task ErrorAsync<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null) =>
            await WriteAsync(LogLevel.Error, data, exception, formatter);

        /// <summary>
        /// Writes a log entry on critical level.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        public void Critical<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null) =>
            Write(LogLevel.Critical, data, exception, formatter);

        /// <summary>
        /// Writes a log entry on critical level.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        public async Task CriticalAsync<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null) =>
            await WriteAsync(LogLevel.Critical, data, exception, formatter);

        public void Dispose() { }
    }
}