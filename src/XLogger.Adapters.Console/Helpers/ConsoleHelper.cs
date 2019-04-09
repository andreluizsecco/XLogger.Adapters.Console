using System;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;

namespace XLogger.Adapters.Console.Helpers
{
    public class ConsoleHelper
    {
        private static readonly Regex _dateTimeRegex = new Regex(@"(.*){@DateTime:*([^}]*)}(.*)");

        public static string FormatOutput<TData>(string outputFormat, LogLevel logLevel, TData data, Exception exception)
        {
            var match = _dateTimeRegex.Match(outputFormat);
            var dateTimeFormat = match.Groups[2].Value;

            var result = match.Groups[1].Value +
                     DateTime.Now.ToString(dateTimeFormat) +
                     match.Groups[3].Value;

            result = result
                .Replace("{@LogLevel}", logLevel.ToString())
                .Replace("{@Data}", data.ToString())
                .Replace("{@Exception}", exception?.ToString() ?? string.Empty)
                .Replace(@"{NewLine}", Environment.NewLine);

            return result;
        }
    }
}