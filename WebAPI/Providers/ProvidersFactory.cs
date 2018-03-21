using System;

using TestTask.SDK.Models;

namespace TestTask.SDK.Providers
{
    public static class ProvidersFactory
    {
        public static ICacher Cacher = null;
        public static ILogger Logger = null;

        public static IFeedCollectionProvider<IFeed> GetProvider(ProviderType type, ICacher cacher = null, ILogger logger = null)
        {
            ICacher __cacher = cacher ?? Cacher;
            ILogger __logger = logger ?? Logger;

            switch (type)
            {
                case (ProviderType.RSS):
                case (ProviderType.Atom):
                    {
                        RSSAtomProvider.Logger = __logger;
                        return new RSSAtomProvider();
                    }

                default: throw new Exception("Undefined type provider");
            }
        }
    }
}
