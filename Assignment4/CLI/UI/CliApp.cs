using Entities;
using RepositoryContracts;

namespace CLI.UI;

public class CliApp(
    ICommentRepository commentRepository,
    IPostRepository postRepository,
    IUserRepository userRepository)
{
    public async Task Run()
    {
        Console.Title = "Forum";
        Console.WriteLine("Welcome to the forum!");
        MainMenuView mainMenu = new MainMenuView();
        User? currentUser = null;
        while (currentUser == null)
        {
            LoginView loginView = new LoginView(userRepository);
            currentUser = await loginView.Register();
        }

        while (true)
        {
            Console.WriteLine("User created, showing menu...");
            string? choice = mainMenu.Choose();
            Console.WriteLine("You chose: " + choice);
            switch (choice)
            {
                case "1":
                {
                    ViewPostsView viewPostsView = new ViewPostsView(postRepository);
                    await viewPostsView.Show();
                    break;
                }
                case "2":
                {
                    ViewOnePostView viewOnePostView = new ViewOnePostView(postRepository, commentRepository);
                    await viewOnePostView.Show();
                    break;
                }
                case "3":
                {
                    CreatePostView createPostView = new CreatePostView(currentUser, postRepository);
                    await createPostView.Show();
                    break;
                }
                case "4":
                {
                    CreateCommentView createCommentView = new CreateCommentView(currentUser, commentRepository, postRepository);
                    await createCommentView.Show();
                    break;
                }
                case "5":
                {
                    Console.WriteLine("Goodbye! 👋");
                    Environment.Exit(0);
                    return;
                }
            }
        }
    }
}