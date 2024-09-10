using Entities;
using RepositoryContracts;

namespace CLI.UI;

public class CliApp(
    ICommentRepository commentRepository,
    IPostRepository postRepository,
    IUserRepository userRepository)
{
    private readonly ICommentRepository _commentRepository = commentRepository;
    private readonly IPostRepository _postRepository = postRepository;
    private readonly IUserRepository _userRepository = userRepository;

    public async void Run()
    {
        Console.Title = "Forum";
        Console.WriteLine("Welcome to the forum!");
        MainMenuView mainMenu = new MainMenuView();
        User? currentUser = null;
        while (currentUser == null)
        {
            LoginRegisterView loginRegisterView = new LoginRegisterView(_userRepository);
            currentUser = await loginRegisterView.Register();
        }

        string choice = mainMenu.Choose();
        switch (choice)
        {
            case "1":
            {
                break;
            }
            case "2":
            {
                break;
            }
        }
    }
}