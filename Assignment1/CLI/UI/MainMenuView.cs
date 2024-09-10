namespace CLI.UI;

public class MainMenuView
{
    public string Choose()
    {
        Console.WriteLine("1) View posts");
        Console.WriteLine("2) View one post");
        Console.WriteLine("3) Create post");
        Console.WriteLine("4) Create comment");
        Console.WriteLine("5) Exit");
        string? cmd = Console.ReadLine();
        if (cmd == "5")
        {
            Environment.Exit(0);
            return null;
        }

        return cmd;
    }
}