using System.Text;
using System.Text.Json;
using Entities;
using RepositoryContracts;

namespace FileRepository;

public class UserFileRepository : IUserRepository
{
    private readonly string _filePath = "users.json";

    public UserFileRepository()
    {
        if (File.Exists(_filePath)) return;
        File.Create(_filePath);
        FileStream fs = File.Open(_filePath, FileMode.Append);
        byte[] data = Encoding.UTF8.GetBytes("[]");
        fs.WriteAsync(data);
        fs.Close();
    }

    public async Task<User> AddAsync(User user)
    {
        string usersAsJson = await File.ReadAllTextAsync(_filePath);
        List<User>? users = JsonSerializer.Deserialize<List<User>>(usersAsJson);
        if(users == null) throw new Exception("No users parsed");
        user.Id = users.Count + 1;
        users.Add(user);
        return user;
    }

    public async Task UpdateAsync(User user)
    {
        string usersAsJson = await File.ReadAllTextAsync(_filePath);
        List<User>? users = JsonSerializer.Deserialize<List<User>>(usersAsJson);
        if(users == null) throw new Exception("No users parsed");
        User? foundUser = users.Find(u => u.Id == user.Id);
        if (foundUser == null) throw new Exception("User not found");
        foundUser.Id = user.Id;
        foundUser.Username = user.Username;
        foundUser.Password = user.Password;
    }

    public Task DeleteAsync(User user)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetSingleAsync(int id)
    {
        string usersAsJson = await File.ReadAllTextAsync(_filePath);
        List<User>? users = JsonSerializer.Deserialize<List<User>>(usersAsJson);
        User? user = users?.Find(u => u.Id == id);
        if (user == null) throw new Exception("User not found");
        return user;
    }

    public IQueryable<User> GetMany()
    {
        string usersAsJson = File.ReadAllText(_filePath);
        List<User>? users = JsonSerializer.Deserialize<List<User>>(usersAsJson);
        if(users == null) throw new Exception("No users parsed");
        return users.AsQueryable();
    }
}