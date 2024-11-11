using Entities;

namespace Client.Services;

public interface IUserService
{
   public Task<User>AddUserAsync(User user);
   public Task UpdateUserAsync(int id, User user);
}