using Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IUserRepository userRepository)
{
    private readonly IUserRepository _userRepository = userRepository;
    
    [HttpGet]
    public IEnumerable<User> GetUsers()
    {
        return _userRepository.GetMany();
    }
    
    [HttpGet("{id}")]
    public async Task<User> GetUser(int id)
    {
        return await _userRepository.GetSingleAsync(id);
    }
    
    [HttpPost]
    public async Task<User> AddUser(User user)
    {
        return await _userRepository.AddAsync(user);
    }
    
    [HttpPut]
    public async Task UpdateUser(User user)
    {
        await _userRepository.UpdateAsync(user);
    }
    
    [HttpDelete("{id}")]
    public async Task DeleteUser(int id)
    {
        var user = await _userRepository.GetSingleAsync(id);
        await _userRepository.DeleteAsync(user);
    }
}