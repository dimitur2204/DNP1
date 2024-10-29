using Entities;
using RepositoryContracts;

namespace CLI.UI;

public class ViewOnePostView(IPostRepository postRepository, ICommentRepository commentRepository) : IView
{
    public async Task Show()
    {
        int? id = null;
        Post? post = null;
        while (id is null || post is null)
        {
            try
            {
                Console.WriteLine("Enter the ID of the post you want to view:");
                id = int.Parse(Console.ReadLine());
                post = await postRepository.GetSingleAsync((int)id);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input or post does not exist.");
                Console.WriteLine("If you want to go back to menu, type 'back'.");
                string? cmd = Console.ReadLine();
                if (cmd == "back") return;
            }
        }

        Console.WriteLine("Title: " + post.Title);
        Console.Write("Body: ");
        for (int i = 0; i < post.Body.Length; i += 50)
        {
            Console.WriteLine(post.Body.Substring(i, Math.Min(50, post.Body.Length - i)));
        }

        Console.WriteLine();
        Console.WriteLine("Comments:");
        List<Comment> comments = commentRepository.GetMany().Where(c => c.PostId == id).ToList();
        foreach (var comment in comments)
        {
            Console.WriteLine("ID: " + comment.Id);
            Console.WriteLine("Body: " + comment.Body);
            Console.WriteLine();
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}