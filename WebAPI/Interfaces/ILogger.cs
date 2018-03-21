using System;
//namespace
namespace TestTask.SDK
{
    public interface ILogger
    {
        //extract LogInfo entity and put these properties there. 
        //Refactor this method to receive that entity
        void Log(string className, string methodName, Exception exception);
    }
}
