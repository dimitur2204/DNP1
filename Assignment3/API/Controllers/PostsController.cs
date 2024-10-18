using Microsoft.AspNetCore.Mvc;
using RepositoryContracts;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController(IPostRepository postRepository) : ControllerBase
{
    private readonly IPostRepository _postRepository = postRepository;
}