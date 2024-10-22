using Microsoft.AspNetCore.Mvc;
using RepositoryContracts;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IUserRepository userRepository)
{
    private readonly IUserRepository _userRepository = userRepository;
}