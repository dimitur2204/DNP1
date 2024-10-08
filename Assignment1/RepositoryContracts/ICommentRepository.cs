using Entities;

namespace RepositoryContracts;

public interface ICommentRepository
{   
    Task<Comment> AddAsync(Comment comment);
    Task UpdateAsync(Comment comment);
    Task DeleteAsync(Comment comment);
    Task GetSingleAsync(int id);
    IQueryable<Comment> GetMany();
}