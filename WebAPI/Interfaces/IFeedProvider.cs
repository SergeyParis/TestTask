using TestTask.SDK.Models;

namespace TestTask.SDK.Providers
{
    public interface IFeedProvider<out TElement>
        where TElement : IItem
    {
        IFeed<TElement> GetFeedCollection(string url);
    }
}
