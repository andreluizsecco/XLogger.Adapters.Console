using System;
using Microsoft.Extensions.Logging;

namespace XLogger.Adapters.Console
{
    public class ConsoleLogger : IConsoleLogger
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public void Critical<Tstate>(Tstate state, Exception exception = null, Func<Tstate, Exception, object> formatter = null)
        {
            throw new NotImplementedException();
        }

        public void Debug<Tstate>(Tstate state, Exception exception = null, Func<Tstate, Exception, object> formatter = null)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Error<Tstate>(Tstate state, Exception exception = null, Func<Tstate, Exception, object> formatter = null)
        {
            System.Console.WriteLine(state);
        }

        public void Information<Tstate>(Tstate state, Exception exception = null, Func<Tstate, Exception, object> formatter = null)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public bool IsOnDemand()
        {
            return false;
        }

        public void Trace<Tstate>(Tstate state, Exception exception = null, Func<Tstate, Exception, object> formatter = null)
        {
            throw new NotImplementedException();
        }

        public void Warning<Tstate>(Tstate state, Exception exception = null, Func<Tstate, Exception, object> formatter = null)
        {
            throw new NotImplementedException();
        }

        public void Write<Tstate>(LogLevel logLevel, EventId eventId, Tstate state, Exception exception, Func<Tstate, Exception, string> formatter)
        {
            System.Console.WriteLine("------------------------------------ TEST LOG ------------------------------");
            System.Console.WriteLine(state);
        }

        public void Write<Tstate>(Tstate state, Exception exception = null, Func<Tstate, Exception, object> formatter = null)
        {
            throw new NotImplementedException();
        }
    }
}