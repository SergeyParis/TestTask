using TestTask.Data;
using TestTask.SDK;

namespace TestTask.WebAPI
{
    internal static class CacheFactory
    {
        public static ICacher GetCacher(IUser currentUser) => new CacheDB(currentUser);
    }
}