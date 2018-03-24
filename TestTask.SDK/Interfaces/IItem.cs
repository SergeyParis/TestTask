using System;

namespace TestTask.SDK
{
    public interface IItem
    {
        string Id { get; set; }
        string Description { get; set; }
        string TypeDescription { get; set; }
        string Link { get; set; }
        string Title { get; set; }
        DateTime PublishDate { get; set; }
    }
}
