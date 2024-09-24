using Entities;
using RepositoryContracts;

namespace CLI.UI;

public class CreateCommentView(User currentUser, ICommentRepository commentRepository, IPostRepository postRepository)
    : IView
{
    public async Task Show()
    {
        int? postId = null;
        Post? post = null;
        while (postId is null || post is null)
        {
            try
            {
                Console.WriteLine("Enter post ID:");
                postId = int.Parse(Console.ReadLine());
                post = await postRepository.GetSingleAsync((int)postId);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input or post does not exist.");
                Console.WriteLine("If you want to go back to menu, type 'back'.");
                string? cmd = Console.ReadLine();
                if (cmd == "back") return;
            }
        }

        Console.WriteLine("Enter comment body:");
        string content = Console.ReadLine();
        Comment comment = new Comment();
        comment.Body = content;
        comment.PostId = (int)postId;
        comment.WriterId = currentUser.Id;
        commentRepository.AddAsync(comment);
        Console.WriteLine("Comment added successfully. ✅");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}