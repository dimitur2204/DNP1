
using Entities;
using RepositoryContracts;

namespace InMemoryRepositories;

public class UserInMemoryRepository:IUserRepository
{
    private readonly List<User> _users = new List<User>();
    
    public Task<User> AddAsync(User user)
    {
        if (user == null) throw new Exception("User can't be null");
        int? newId = 1;
        if (_users.Count != 0) newId = _users.Max(u => u.Id) + 1;
        user.Id = newId;
        _users.Add(user);
        return Task.FromResult(user);
    }

    public Task UpdateAsync(User user)
    {
        User? foundUser = _users.SingleOrDefault(u => u.Id == user.Id);
        if (foundUser == null) throw new Exception("User does not exist");
        foundUser.Id = user.Id;
        foundUser.Username = user.Username;
        foundUser.Password = user.Password;
        return Task.CompletedTask;
    }

    public Task DeleteAsync(User user)
    {
        User? foundUser = _users.SingleOrDefault(u => u.Id == user.Id);
        if (foundUser == null) throw new Exception("User does not exist");
        _users.Remove(foundUser);
        return Task.CompletedTask;
    }

    public Task GetSingleAsync(int id)
    {
        User? foundUser = _users.SingleOrDefault(u => u.Id == id);
        if (foundUser == null) throw new Exception("User does not exist");
        return Task.FromResult(foundUser);
    }

    public IQueryable<User> GetMany()
    {
        if (_users.Count == 0) throw new Exception("No users found");
        return _users.AsQueryable();     
    }
}