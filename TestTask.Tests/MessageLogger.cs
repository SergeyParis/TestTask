using System;
using TestTask.SDK;

namespace TestTask.Tests
{
    //this class does not do anything
    //change implementation
    //and why it is here? it should be in SDK
    internal sealed class MessageLogger : ILogger
    {
        public string Message { get; set; }
        public void Log(string className, string methodName, Exception exception) => Message = exception.Message;
    }
}
