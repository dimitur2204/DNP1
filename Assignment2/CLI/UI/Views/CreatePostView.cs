using Entities;
using RepositoryContracts;

namespace CLI.UI;

public class CreatePostView(User currentUser, IPostRepository postRepository) : IView
{
    public async void Show()
    {
        Console.WriteLine("Enter post title:");
        string title = Console.ReadLine();
        Console.WriteLine("Enter post content:");
        string content = Console.ReadLine();
        Post post = new Post();
        post.Title = title;
        post.Body = content;
        post.WriterId = currentUser.Id;
        await postRepository.AddAsync(post);
        Console.WriteLine("Post created successfully. ✅");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}