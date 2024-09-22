using Entities;
using RepositoryContracts;

namespace CLI.UI;

public class CliApp(
    ICommentRepository commentRepository,
    IPostRepository postRepository,
    IUserRepository userRepository)
{
    public async void Run()
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
            string choice = await mainMenu.Choose();
            switch (choice)
            {
                case "1":
                {
                    ViewPostsView viewPostsView = new ViewPostsView(postRepository);
                    viewPostsView.Show();
                    break;
                }
                case "2":
                {
                    ViewOnePostView viewOnePostView = new ViewOnePostView(postRepository, commentRepository);
                    viewOnePostView.Show();
                    break;
                }
                case "3":
                {
                    CreatePostView createPostView = new CreatePostView(currentUser, postRepository);
                    createPostView.Show();
                    break;
                }
                case "4":
                {
                    CreateCommentView createCommentView = new CreateCommentView(currentUser, commentRepository, postRepository);
                    createCommentView.Show();
                    break;
                }
                case "5":
                {
                    Environment.Exit(0);
                    break;
                }
            }
        }
    }
}