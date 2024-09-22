using System.Text;
using System.Text.Json;
using Entities;
using RepositoryContracts;

namespace FileRepository;

public class CommentsFileRepository : ICommentRepository
{
    private readonly string _filePath = "comments.json";
    public CommentsFileRepository()
    {
        if (!File.Exists(_filePath))
        {
            File.WriteAllText(_filePath, "[]"); 
        }
    }

    public async Task<Comment> AddAsync(Comment comment)
    {
        string commentsAsJson = await File.ReadAllTextAsync(_filePath);
        List<Comment>? comments = JsonSerializer.Deserialize<List<Comment>>(commentsAsJson);
        if(comments == null) throw new Exception("No comments parsed");
        comment.Id = comments.Count + 1;
        comments.Add(comment);
        commentsAsJson = JsonSerializer.Serialize(comments);
        await File.WriteAllTextAsync(_filePath, commentsAsJson);
        return comment;
    }

    public async Task UpdateAsync(Comment comment)
    {
        string commentsAsJson = await File.ReadAllTextAsync(_filePath);
        List<Comment>? comments = JsonSerializer.Deserialize<List<Comment>>(commentsAsJson);
        if(comments == null) throw new Exception("No comments parsed");
        Comment? foundComment = comments.Find(c => c.Id == comment.Id);
        if (foundComment == null) throw new Exception("Comment not found");
        foundComment.Id = comment.Id;
        foundComment.Body = comment.Body;
        foundComment.PostId = comment.PostId;
        foundComment.WriterId = comment.WriterId;
        commentsAsJson = JsonSerializer.Serialize(comments);
        await File.WriteAllTextAsync(_filePath, commentsAsJson);
    }

    public async Task DeleteAsync(Comment comment)
    {
       string commentsAsJson = await File.ReadAllTextAsync(_filePath);
        List<Comment>? comments = JsonSerializer.Deserialize<List<Comment>>(commentsAsJson);
        if(comments == null) throw new Exception("No comments parsed");
        Comment? foundComment = comments.Find(c => c.Id == comment.Id);
        if (foundComment == null) throw new Exception("Comment not found");
        comments.Remove(foundComment); 
        commentsAsJson = JsonSerializer.Serialize(comments);
        await File.WriteAllTextAsync(_filePath, commentsAsJson);
    }

    public async Task<Comment> GetSingleAsync(int id)
    {
        string commentsAsJson = await File.ReadAllTextAsync(_filePath);
        List<Comment>? comments = JsonSerializer.Deserialize<List<Comment>>(commentsAsJson);
        Comment? comment = comments?.Find(c => c.Id == id);
        if (comment == null) throw new Exception("Comment not found");
        return comment;
    }

    public IQueryable<Comment> GetMany()
    {
        string commentsAsJson = File.ReadAllText(_filePath);
        List<Comment>? comments = JsonSerializer.Deserialize<List<Comment>>(commentsAsJson);
        if(comments == null) throw new Exception("No comments parsed");
        return comments.AsQueryable();
    }
}