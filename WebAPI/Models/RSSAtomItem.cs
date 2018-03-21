using System;
using System.Collections;
using System.Collections.Generic;
//usings
namespace TestTask.SDK.Models
{
    public sealed class RSSAtomItem : IItem
    {
        //make private set
        //it should not be static
        //it should be initialized from constructor
        //or via Dependency Injection container
        internal static ILogger Logger { get; set; }

        public string Id { get; }
        public string Description { get; }
        public string TypeDescription { get; }
        public string Link { get; }
        public string Title { get; }
        public DateTime PublishDate { get; }

        public RSSAtomItem(string id, string description, string typeDescription, string link, string title, DateTime publishDate)
        {
            if (id == null ||
                link == null ||
                title == null ||
                typeDescription == null)
            {
                Logger?.Log(nameof(RSSAtomItem), nameof(RSSAtomItem), new ArgumentNullException("Arguments must be not-null"));
                //you should throw exception here
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
            //invert to remove nesting
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

        //remove
        public override int GetHashCode() => base.GetHashCode();
    }
}
