using System.Text;
using System.Text.Json;
using Entities;
using RepositoryContracts;

namespace FileRepository;

public class PostsFileRepository : IPostRepository
{
    private readonly string _filePath = "posts.json";
    public PostsFileRepository()
    {
        if (!File.Exists(_filePath))
        {
            File.WriteAllText(_filePath, "[]"); 
        }
    }
    
    public async Task<Post> AddAsync(Post post)
    {
        string postsJson = await File.ReadAllTextAsync(_filePath);      
        List<Post>? posts = JsonSerializer.Deserialize<List<Post>>(postsJson);
        if(posts == null) throw new Exception("No posts parsed");
        post.Id = posts.Count + 1;
        posts.Add(post);
        postsJson = JsonSerializer.Serialize(posts);
        await File.WriteAllTextAsync(_filePath, postsJson);
        return post;
    }

    public async Task UpdateAsync(Post post)
    {
        string postsJson = await File.ReadAllTextAsync(_filePath);
        List<Post>? posts = JsonSerializer.Deserialize<List<Post>>(postsJson);
        if(posts == null) throw new Exception("No posts parsed");
        Post? foundPost = posts.Find(p => p.Id == post.Id);
        if (foundPost == null) throw new Exception("Post not found");
        foundPost.Id = post.Id;
        foundPost.Title = post.Title;
        foundPost.Body = post.Body;
        foundPost.WriterId = post.WriterId;
        postsJson = JsonSerializer.Serialize(posts);
        await File.WriteAllTextAsync(_filePath, postsJson);
    }

    public async Task DeleteAsync(Post post)
    {
        string postsJson = await File.ReadAllTextAsync(_filePath);
        List<Post>? posts = JsonSerializer.Deserialize<List<Post>>(postsJson);
        if(posts == null) throw new Exception("No posts parsed");
        Post? foundPost = posts.Find(p => p.Id == post.Id);
        if (foundPost == null) throw new Exception("Post not found");
        posts.Remove(foundPost);
        postsJson = JsonSerializer.Serialize(posts);
        await File.WriteAllTextAsync(_filePath, postsJson);
    }

    public async Task<Post> GetSingleAsync(int id)
    {
        string postsJson = await File.ReadAllTextAsync(_filePath);
        List<Post>? posts = JsonSerializer.Deserialize<List<Post>>(postsJson);
        Post? post = posts?.Find(p => p.Id == id);
        if (post == null) throw new Exception("Post not found");
        return post;
    }

    public IQueryable<Post> GetMany()
    {
        string postsJson = File.ReadAllText(_filePath);
        List<Post>? posts = JsonSerializer.Deserialize<List<Post>>(postsJson);
        if(posts == null) throw new Exception("No posts parsed");
        return posts.AsQueryable();
    }
}