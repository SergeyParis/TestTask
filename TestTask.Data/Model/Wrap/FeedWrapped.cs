using System;
using System.Collections;
using System.Collections.Generic;
using TestTask.SDK;

namespace TestTask.Data
{
    public sealed class FeedWrapped : IFeed<IItem>
    {
        private IFeed<IItem> _state;
        public IFeed<IItem> State
        {
            get => _state ?? new RSSAtomFeed();
            set
            {
                if (value != null)
                    _state = value;
            }
        }

        public FeedWrapped()
        {
            State = new RSSAtomFeed();
        }
        public FeedWrapped(IFeed<IItem> state)
        {
            State = state;
        }
        
        public string Id { get => State.Id; set => State.Id = value; }
        public string Name { get => State.Name; set => State.Name = value; }
        public string Title { get => State.Title; set => State.Title = value; }
        public string Language { get => State.Language; set => State.Language = value; }
        public DateTime LastUpdatedTime { get => State.LastUpdatedTime; set => State.LastUpdatedTime = value; }

        public string AddFeed(IItem element) => State.AddFeed(element);
        public IEnumerator<IItem> GetEnumerator() => State.GetEnumerator();
        public IItem GetFeed(string id) => State.GetFeed(id);
        public IEnumerable<IItem> GetFeeds() => State.GetFeeds();
        IEnumerator IEnumerable.GetEnumerator() => State.GetEnumerator();
    }
}
