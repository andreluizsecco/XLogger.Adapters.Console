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

        public ConsoleLogger(Action<ConsoleLoggerOptions> options) : this() =>
            options.Invoke((ConsoleLoggerOptions)Options);

        public IDisposable BeginScope<TState>(TState state) => null;

        private void Write<Tstate>(LogLevel logLevel, Tstate state, Exception exception, Func<Tstate, Exception, object> formatter = null)
        {
            if (formatter != null)
                System.Console.WriteLine(formatter.Invoke(state, exception));
            else
            {
                var dateTime = string.IsNullOrEmpty(Options.DateTimeFormat)? 
                    DateTime.Now.ToLocalTime().ToString() :
                    DateTime.Now.ToString(Options.DateTimeFormat);

                System.Console.WriteLine($"{dateTime} [{logLevel.ToString()}] {state}");
                if (exception != null)
                    System.Console.WriteLine(exception.ToString());
            }
        }

        public void Write<Tstate>(LogLevel logLevel, EventId eventId, Tstate state, Exception exception, Func<Tstate, Exception, string> formatter) =>
            Write(logLevel, state, exception);

        public void Trace<Tstate>(Tstate state, Exception exception = null, Func<Tstate, Exception, object> formatter = null) =>
            Write(LogLevel.Trace, state, exception, formatter);

        public void Debug<Tstate>(Tstate state, Exception exception = null, Func<Tstate, Exception, object> formatter = null) =>
            Write(LogLevel.Debug, state, exception, formatter);

        public void Critical<Tstate>(Tstate state, Exception exception = null, Func<Tstate, Exception, object> formatter = null) =>
            Write(LogLevel.Critical, state, exception, formatter);

        public void Information<Tstate>(Tstate state, Exception exception = null, Func<Tstate, Exception, object> formatter = null) =>
            Write(LogLevel.Information, state, exception, formatter);

        public void Warning<Tstate>(Tstate state, Exception exception = null, Func<Tstate, Exception, object> formatter = null) =>
            Write(LogLevel.Warning, state, exception, formatter);

        public void Error<Tstate>(Tstate state, Exception exception = null, Func<Tstate, Exception, object> formatter = null) =>
            Write(LogLevel.Error, state, exception, formatter);

        public void Dispose() { }
    }
}