using System;
//remove line
using TestTask.SDK.Models;

namespace TestTask.SDK.Providers
{
    //why do you need this factory if in any case it returns RSSAtomProvider?
    public static class ProvidersFactory
    {
        public static ICacher Cacher = null;
        public static ILogger Logger = null;

        public static IFeedProvider<IItem> GetProvider(ProviderType type, ICacher cacher = null, ILogger logger = null)
        {//change naming, remove __
            ICacher __cacher = cacher ?? Cacher; //it is not used
            ILogger __logger = logger ?? Logger;

            switch (type)
            {
                case (ProviderType.RSS):
                case (ProviderType.Atom):
                    {
                        //logger should not be set here
                        //because in this case it looks like a builder more
                        //not a factory
                        RSSAtomProvider.Logger = __logger;
                        return new RSSAtomProvider();
                    }
                //Never throw base class Exception, use throw ArgumentException
                default: throw new Exception("Undefined type provider");
            }
        }
    }
}
