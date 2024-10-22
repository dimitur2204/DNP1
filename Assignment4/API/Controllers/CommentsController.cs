using Microsoft.AspNetCore.Mvc;
using RepositoryContracts;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentsController(ICommentRepository commentRepository) : ControllerBase
{
    private readonly ICommentRepository _commentRepository = commentRepository;
}