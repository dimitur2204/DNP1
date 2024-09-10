using Entities;
using RepositoryContracts;

namespace FileRepository;

public class UserFileRepository : IUserRepository
{
    public Task<User> AddAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task GetSingleAsync(int id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<User> GetMany()
    {
        throw new NotImplementedException();
    }
}