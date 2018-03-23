using System;

namespace TestTask.SDK
{
    public interface ILogger
    {
        void Log(string className, string methodName, Exception exception);
    }
}
