namespace Entities;

public class Comment
{
    public int Id { get; set; }
    public string Body { get; set; }
    public int WriterId { get; set; }
    public int PostId { get; set; }
    public DateTime CreatedAt { get; set; }
}
