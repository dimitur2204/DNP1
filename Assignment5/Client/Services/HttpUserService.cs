using System.Text.Json;
using Entities;

namespace Client.Services;

public class HttpUserService(HttpClient client) : IUserService
{
    public async Task<User> AddUserAsync(User user)
    {
        HttpResponseMessage httpResponse = await client.PostAsJsonAsync("api/users", user);
        string response = await httpResponse.Content.ReadAsStringAsync();
        if (!httpResponse.IsSuccessStatusCode)
        {
            throw new Exception(response);
        }
        var responseUser = JsonSerializer.Deserialize<User>(response);
        if (responseUser == null)
        {
            throw new Exception("Failed to add user");
        }
        return responseUser;
    }

    public async Task UpdateUserAsync(int id, User user)
    {
        HttpResponseMessage httpResponse = await client.PutAsJsonAsync("api/users", user);
        string response = await httpResponse.Content.ReadAsStringAsync();
        if (!httpResponse.IsSuccessStatusCode)
        {
            throw new Exception(response);
        }
    }
}