using Entities;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentsController(ICommentRepository commentRepository) : ControllerBase
{
    private readonly ICommentRepository _commentRepository = commentRepository;
    
    [HttpGet]
    public IEnumerable<Comment> GetComments()
    {
        return _commentRepository.GetMany();
    }
        
    [HttpGet("{id}")]
    public async Task<Comment> GetComment(int id)
    {
        return await _commentRepository.GetSingleAsync(id);
    }
    
    [HttpPost]
    public async Task<Comment> AddComment(Comment comment)
    {
        return await _commentRepository.AddAsync(comment);
    }
    
    [HttpPut]
    public async Task UpdateComment(Comment comment)
    {
        await _commentRepository.UpdateAsync(comment);
    }
    
    [HttpDelete("{id}")]
    public async Task DeleteComment(int id)
    {
        var comment = await _commentRepository.GetSingleAsync(id);
        await _commentRepository.DeleteAsync(comment);
    }
}