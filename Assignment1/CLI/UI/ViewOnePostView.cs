using Entities;
using RepositoryContracts;

namespace CLI.UI;

public class ViewOnePostView(IPostRepository postRepository, ICommentRepository commentRepository)
{
    public async void ViewPost(int id)
    {
        Post post = await postRepository.GetSingleAsync(id);
        Console.WriteLine("Title: " + post.Title);
        Console.Write("Body: ");
        for (int i = 0; i < post.Body.Length; i += 50)
        {
            Console.WriteLine(post.Body.Substring(i, Math.Min(50, post.Body.Length - i)));
        }
        Console.WriteLine();
        Console.WriteLine("Comments:");
        
        foreach (var comment in post.Comments)
        {
            Console.WriteLine("ID: " + comment.Id);
            Console.WriteLine("Body: " + comment.Body);
            Console.WriteLine();
        }
    }
}