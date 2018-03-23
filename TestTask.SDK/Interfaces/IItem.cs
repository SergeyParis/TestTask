using System;

namespace TestTask.SDK
{
    public interface IItem
    {
        string Id { get; }
        string Description { get; }
        string TypeDescription { get; }
        string Link { get; }
        string Title { get; }
        DateTime PublishDate { get; }
    }
}
