using System.Collections.Generic;
using TestTask.SDK;

namespace TestTask.Data
{
    public interface IUser
    {
        int Id { get; set; }
        string Password { get; set; }
        ICollection<IFeed<IItem>> Feeds { get; set; }

        void AddFeed(IFeed<IItem> feed);
        void RemoveFeed(IFeed<IItem> feed);
    }
}