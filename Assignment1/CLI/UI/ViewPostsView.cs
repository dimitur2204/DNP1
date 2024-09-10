using RepositoryContracts;

namespace CLI.UI;

public class ViewPostsView(IPostRepository postRepository):IMainView
{
    public void Show()
    {
        Console.WriteLine("Posts:");
        foreach (var post in postRepository.GetMany())
        {
            if (post != null)
            {
                Console.Write("ID: " + post.Id + " ");
                Console.WriteLine("Title: " + post.Title);
            }
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }    
}