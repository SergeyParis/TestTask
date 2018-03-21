using System;
using TestTask.SDK;

namespace TestTask.Tests
{
    internal sealed class MessageLogger : ILogger
    {
        public string Message { get; set; }
        public void Log(string className, string methodName, Exception exception) => Message = exception.Message;
    }
}
