using System;

using TestTask.SDK;

namespace TestTask.WebAPI
{
    internal static class CacheFactory
    {
        public static ICacher GetCacher() => new CacheDB();
    }
}