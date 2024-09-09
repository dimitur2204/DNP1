using Entities;

namespace RepositoryContracts;

public interface IUserRepository
{
    Task<Post> AddAsync(Post post);
    Task UpdateAsync(Post post);
    Task DeleteAsync(Post post);
    Task GetSingleAsync(int id);
    IQueryable<Post> GetMany();
}