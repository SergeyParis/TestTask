using System.Collections.Generic;
using TestTask.SDK;

namespace TestTask.Data
{
    public sealed class UserWrapped : IUser
    {
        private IUser _state;
        public IUser State
        {
            get => _state ?? new User();
            set
            {
                if (value != null)
                    _state = value;
            }
        }

        public UserWrapped()
        {
            State = new User();
        }
        public UserWrapped(IUser state)
        {
            State = state;
        }

        public int Id { get => State.Id; set => State.Id = value; }
        public string Password { get => State.Password; set => State.Password = value; }
        public ICollection<IFeed<IItem>> Feeds { get => State.Feeds; set => State.Feeds = value; }

        public void AddFeed(IFeed<IItem> feed) => State.AddFeed(feed);
        public void RemoveFeed(IFeed<IItem> feed) => State.RemoveFeed(feed);
    }
}
