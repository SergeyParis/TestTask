using System;

namespace TestTask.SDK
{
    public sealed class RSSAtomItem : IItem
    {
        internal static ILogger Logger { get; set; }

        public string Id { get; set; }
        public string Description { get; set; }
        public string TypeDescription { get; set; }
        public string Link { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }

        public RSSAtomItem() : this("empty", "d", "td", "l", "t", DateTime.MinValue) { }
        public RSSAtomItem(string id, string description, string typeDescription, string link, string title, DateTime publishDate)
        {
            if (id == null ||
                link == null ||
                title == null ||
                typeDescription == null)
            {
                Logger?.Log(nameof(RSSAtomItem), nameof(RSSAtomItem), new ArgumentNullException("Arguments must be not-null"));

                return;
            }

            Id = id;
            Link = link;
            Title = title;
            TypeDescription = typeDescription;

            if (description != null)
                Description = description;
            if (publishDate != null)
                PublishDate = publishDate;
        }

        public override bool Equals(object obj)
        {
            if (obj is RSSAtomItem)
            {
                RSSAtomItem y = (RSSAtomItem)obj;

                if (Id == y.Id &&
                Link == y.Link &&
                PublishDate == y.PublishDate &&
                Title == y.Title &&
                TypeDescription == y.TypeDescription &&
                Description == y.Description)
                    return true;
            }

            return false;
        }
        public override int GetHashCode() => base.GetHashCode();
    }
}
