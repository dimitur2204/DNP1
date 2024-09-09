using Entities;
using RepositoryContracts;

namespace InMemoryRepositories;

public class CommentInMemoryRepository:ICommentRepository
{
    private readonly List<Comment> _comments = new List<Comment>();
    public Task<Comment> AddAsync(Comment comment)
    {
        if (comment == null) throw new Exception("Comment can't be null");
        int newId = 1;
        if (_comments.Count != 0) newId = _comments.Max(c => c.Id) + 1;
        comment.Id = newId;
        _comments.Add(comment);
        return Task.FromResult(comment);
    }

    public Task UpdateAsync(Comment comment)
    {
        Comment? foundComment = _comments.SingleOrDefault(c => c.Id == comment.Id);
        if (foundComment == null) throw new Exception("Comment does not exist");
        foundComment.Id = comment.Id;
        foundComment.Body = comment.Body;
        foundComment.PostId = comment.PostId;
        foundComment.WriterId = comment.WriterId;
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Comment comment)
    {
        Comment? foundComment = _comments.SingleOrDefault(c => c.Id == comment.Id);
        if (foundComment == null) throw new Exception("Comment does not exist");
        _comments.Remove(foundComment);
        return Task.CompletedTask;
    }

    public Task GetSingleAsync(int id)
    {
        Comment? foundComment = _comments.SingleOrDefault(c => c.Id == id);
        if (foundComment == null) throw new Exception("Comment does not exist");
        return Task.FromResult(foundComment);
    }

    public IQueryable<Comment> GetMany()
    {
        if (_comments.Count == 0) throw new Exception("No comments found");
        return _comments.AsQueryable();
    }
}