using RepositoryContracts;

namespace CLI.UI;

public class ViewPostsView(IPostRepository postRepository):IView
{
    public Task Show()
    {
        Console.WriteLine("Posts:");
        foreach (var post in postRepository.GetMany())
        {
            Console.Write("ID: " + post.Id + " ");
            Console.WriteLine("Title: " + post.Title);
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        return Task.CompletedTask;
    }    
}