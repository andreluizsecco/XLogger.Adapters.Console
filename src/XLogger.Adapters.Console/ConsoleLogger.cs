using System;
using Microsoft.Extensions.Logging;
using XLogger.Options;

namespace XLogger.Adapters.Console
{
    public class ConsoleLogger : IConsoleLogger
    {
        public ILoggerOptions Options { get; }

        public ConsoleLogger() =>
            Options = new ConsoleLoggerOptions();

        public ConsoleLogger(ConsoleLoggerOptions options) =>
            Options = options;

        public ConsoleLogger(Action<ConsoleLoggerOptions> options) : this() =>
            options.Invoke((ConsoleLoggerOptions)Options);

        public IDisposable BeginScope<TData>(TData data) => null;

        public void Write<TData>(LogLevel logLevel, TData data, Exception exception = null, Func<TData, Exception, object> formatter = null)
        {
            if (formatter != null)
                System.Console.WriteLine(formatter.Invoke(data, exception));
            else
                System.Console.WriteLine(Helpers.ConsoleHelper.FormatOutput((Options as ConsoleLoggerOptions).OutputFormat, logLevel, data, exception));
        }

        public void Write<TData>(LogLevel logLevel, EventId eventId, TData data, Exception exception, Func<TData, Exception, string> formatter)
        {
            if (formatter != null)
                Write(logLevel, formatter(data, exception), exception);
            else
                Write(logLevel, data, exception);
        }

        public void Trace<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null) =>
            Write(LogLevel.Trace, data, exception, formatter);

        public void Debug<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null) =>
            Write(LogLevel.Debug, data, exception, formatter);

        public void Information<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null) =>
            Write(LogLevel.Information, data, exception, formatter);

        public void Warning<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null) =>
            Write(LogLevel.Warning, data, exception, formatter);

        public void Error<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null) =>
            Write(LogLevel.Error, data, exception, formatter);

        public void Critical<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null) =>
            Write(LogLevel.Critical, data, exception, formatter);

        public void Dispose() { }
    }
}