namespace TestTask.SDK
{
    public interface ICacher
    {
        void CachingFeed(IFeed<IItem> feed);
        IFeed<IItem> GetFeed(string id);

        string AddItemIntoFeed(string collectionId, IItem feed);

        long GetTimeExistCacheMiliseconds(string id);
    }
}
