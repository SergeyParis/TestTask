namespace TestTask.SDK
{
    public interface IFeedProvider<out TElement>
        where TElement : IItem
    {
        IFeed<TElement> GetFeedCollection(string url);
    }
}
