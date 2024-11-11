using Entities;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController(IPostRepository postRepository) : ControllerBase
{
    private readonly IPostRepository _postRepository = postRepository;

    [HttpGet]
    public IEnumerable<Post> GetPosts()
    {
        return _postRepository.GetMany();
    }

    [HttpGet("{id}")]
    public async Task<Post> GetPost(int id)
    {
        return await _postRepository.GetSingleAsync(id);
    }

    [HttpPost]
    public async Task<Post> AddPost([FromBody] Post post)
    {
        return await _postRepository.AddAsync(post);
    }
    
    [HttpPut]
    public async Task UpdatePost([FromBody] Post post)
    {
        await _postRepository.UpdateAsync(post);
    }
    
    [HttpDelete("{id}")]
    public async Task DeletePost(int id)
    {
        var post = await _postRepository.GetSingleAsync(id);
        await _postRepository.DeleteAsync(post);
    }
}