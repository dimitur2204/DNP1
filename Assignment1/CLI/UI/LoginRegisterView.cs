using Entities;
using RepositoryContracts;

namespace CLI.UI;

public class LoginRegisterView(IUserRepository userRepository)
{
    public async Task<User?> Register()
    {
        Console.WriteLine("1) Register");
        Console.WriteLine("2) Login");
        Console.WriteLine("3) Exit");
        string? cmd = Console.ReadLine();
        switch (cmd)
        {
            case "1" or "2":
            {
                Console.WriteLine("Enter your username:");
                string? username = Console.ReadLine();
                Console.WriteLine("Enter your password:");
                string? password = Console.ReadLine();
                User user = new User();
                user.Username = username;
                user.Password = password;
                await userRepository.AddAsync(user);
                return user;
            }
            case "3":
            {
                Environment.Exit(0);
                return null;
            }
        }

        return null;
    }
}