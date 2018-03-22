using System;
using System.Linq;
using TestTask.Data;
using TestTask.SDK;

namespace TestTask.WebAPI
{
    internal sealed class CacheDB : ICacher
    {
        private readonly FeedContext _db;

        private IUser User { get; set; }


        public CacheDB(IUser currentUser)
        {
            _db = new FeedContext();

            User = currentUser;
        }

        public IFeed<IItem> GetFeed(string id)
        {
            if (id == null || string.IsNullOrEmpty(id))
                return null;

            return _db.Users.First(user => user.Id == User.Id).Feeds.First(feed => feed.Id == id);
        }
        public long GetTimeExistCacheMiliseconds(string id)
        {
            if (id == null || string.IsNullOrEmpty(id))
                return -1;

            return DateTime.Now.Millisecond -
                _db.Users.First(user => user.Id == User.Id)
                .Feeds.First(feed => feed.Id == id).LastUpdatedTime.Millisecond;
        }
        public string AddItemIntoFeed(string collectionId, IItem feed)
        {
            if (collectionId == null || string.IsNullOrEmpty(collectionId) || feed == null)
                return null;

            _db.Users.Find(User.Id).Feeds.First(f => f.Id == collectionId).AddFeed(feed);

            return feed.Id;
        }
        public void CachingFeed(IFeed<IItem> feed)
        {
            if (feed != null)
                _db.Users.Find(User.Id).Feeds.Add(feed);
        }
    }
}