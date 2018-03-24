using System;
using TestTask.SDK;

namespace TestTask.Data
{
    public sealed class ItemWrapped : IItem
    {
        private IItem _state;
        public IItem State
        {
            get => _state ?? new RSSAtomItem();
            set
            {
                if (value != null)
                    _state = value;
            }
        }

        public ItemWrapped()
        {
            State = new RSSAtomItem();
        }
        public ItemWrapped(IItem state)
        {
            State = state;
        }

        public string Id { get => State.Id; set => State.Id = value; }
        public string Description { get => State.Description; set => State.Description = value; }
        public string TypeDescription { get => State.TypeDescription; set => State.TypeDescription = value; }
        public string Link { get => State.Link; set => State.Link = value; }
        public string Title { get => State.Title; set => State.Title = value; }
        public DateTime PublishDate { get => State.PublishDate; set => State.PublishDate = value; }
    }
}
