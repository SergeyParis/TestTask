using System;

namespace TestTask.SDK.Models
{
    public interface IFeed
    {
        string Id { get; }
        string Description { get; }
        string TypeDescription { get; }
        string Link { get; }
        string Title { get; }
        DateTime PublishDate { get; }
    }
}
