using System;

using TestTask.SDK;
//usings + namespace
namespace TestTask.WebAPI
{
    //Why do you need factory if you have only 1 type of ICacher?
    internal static class CacheFactory
    {
        public static ICacher GetCacher() => new CacheDB();
    }
}