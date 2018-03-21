using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestTask.SDK.Models;

namespace TestTask.SDK.Providers
{
    public interface IFeedCollectionProvider<TCollection, TElement> : IFeedCollectionProvider
        where TCollection : IFeedCollection<TElement>
        where TElement : IFeed
    {
        IFeedCollection<TElement> GetFeedCollection(string url);
    }
}
