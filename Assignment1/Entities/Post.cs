namespace Entities;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public int WriterId { get; set; }
    public DateTime CreatedAt { get; set; }
}