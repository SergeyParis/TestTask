using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestTask.SDK.Models;
//usings + namespace
namespace TestTask.SDK.Providers
{
    public interface IFeedProvider<out TElement>
        where TElement : IItem
    {
        IFeed<TElement> GetFeedCollection(string url);
    }
}
