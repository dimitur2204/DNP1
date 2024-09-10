using Entities;
using RepositoryContracts;

namespace CLI.UI;

public class LoginView(IUserRepository userRepository)
{
    public async Task<User?> Register()
    {
        Console.WriteLine("1) Login");
        Console.WriteLine("2) Exit");
        string? cmd = Console.ReadLine();
        switch (cmd)
        {
            case "1":
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
            case "2":
            {
                Environment.Exit(0);
                return null;
            }
        }

        return null;
    }
}