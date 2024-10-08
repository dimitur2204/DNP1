﻿using Entities;
using RepositoryContracts;

namespace InMemoryRepositories;

public class PostInMemoryRepository : IPostRepository
{
    private readonly List<Post> _posts = new List<Post>();

    public Task<Post> AddAsync(Post? post)
    {
        if (post == null) throw new Exception("Post can't be null");
        if (_posts.Count == 0) return null;
        post.Id = _posts.Max(p => p.Id) + 1;
        _posts.Add(post);
        return Task.FromResult(post);
    }

    public Task UpdateAsync(Post post)
    {
        Post? foundPost = _posts.SingleOrDefault(p => p.Id == post.Id);
        if (foundPost == null) throw new Exception("Post does not exist");
        foundPost.Id = post.Id;
        foundPost.Body = post.Body;
        foundPost.Title = post.Title;
        foundPost.WriterId = post.WriterId;
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Post post)
    {
        Post? foundPost = _posts.SingleOrDefault(p => p.Id == post.Id);
        if (foundPost == null) throw new Exception("Post does not exist");
        _posts.Remove(foundPost);
        return Task.CompletedTask;
    }

    public Task GetSingleAsync(int id)
    {
        Post? foundPost = _posts.SingleOrDefault(p => p.Id == id);
        if (foundPost == null) throw new Exception("Post does not exist");
        return Task.FromResult(foundPost);
    }

    public IQueryable<Post?> GetMany()
    {
        if (_posts.Count == 0) throw new Exception("No posts found"); 
        return _posts.AsQueryable();
    }
}