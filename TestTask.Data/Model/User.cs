using System.Collections.Generic;
using System.Security.Cryptography;
using TestTask.SDK;

namespace TestTask.Data
{
    public class User : IUser
    {
        private string _password;

        internal ILogger Logger { get; set; }

        public int Id { get; set; }
        public string Password
        {
            get => _password;
            set
            {
                _password = HashingPassword(value);
            }
        }
        public ICollection<IFeed<IItem>> Feeds { get; set; }

        public User() : this("empty", new[] { new RSSAtomFeed() }) { }
        public User(string password, ICollection<IFeed<IItem>> feeds = null)
        {
            Password = password;

            if (feeds == null)
                feeds = new[] { new RSSAtomFeed() };

            Feeds = feeds;
        }

        public void AddFeed(IFeed<IItem> feed)
        {
            if (feed != null)
                Feeds.Add(feed);
        }
        public void RemoveFeed(IFeed<IItem> feed)
        {
            if (feed != null)
                Feeds.Remove(feed);
        }

        protected virtual string HashingPassword(string password)
        {
            return MD5.Create(password).ToString();
        }
    }
}