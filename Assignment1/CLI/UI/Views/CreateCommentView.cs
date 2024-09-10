using Entities;
using RepositoryContracts;

namespace CLI.UI;

public class CreateCommentView(User currentUser, ICommentRepository commentRepository):IView
{
    public void Show()
    {
        Console.WriteLine("Enter post ID:");
        int postId = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter comment body:");
        string content = Console.ReadLine();
        Comment comment = new Comment();
        comment.Body = content;
        comment.PostId = postId;
        comment.WriterId = currentUser.Id;
        commentRepository.AddAsync(comment);
        Console.WriteLine("Comment added successfully. ✅");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }    
}