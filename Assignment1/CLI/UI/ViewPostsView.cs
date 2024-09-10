using RepositoryContracts;

namespace CLI.UI;

public class ViewPostsView(IPostRepository postRepository)
{
    public void ViewPosts()
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
    }    
}