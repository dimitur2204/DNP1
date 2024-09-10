using CLI.UI;
using InMemoryRepositories;
using RepositoryContracts;

Console.WriteLine("Initializing...");
ICommentRepository inMemoryCommentRepository = new CommentInMemoryRepository();
IPostRepository inMemoryPostRepository = new PostInMemoryRepository();
IUserRepository inMemoryUserRepository = new UserInMemoryRepository();
inMemoryUserRepository.AddAsync(new Entities.User { Username = "admin", Password = "admin" }).Wait();
inMemoryUserRepository.AddAsync(new Entities.User { Username = "user", Password = "user" }).Wait();
inMemoryPostRepository.AddAsync(new Entities.Post { Title = "First post", Body = "First post content", WriterId = 1 })
    .Wait();
inMemoryPostRepository.AddAsync(new Entities.Post { Title = "Second post", Body = "Second post content", WriterId = 1 })
    .Wait();
inMemoryCommentRepository.AddAsync(new Entities.Comment { Body = "First comment", PostId = 1, WriterId = 1 }).Wait();
inMemoryCommentRepository.AddAsync(new Entities.Comment { Body = "Second comment", PostId = 2, WriterId = 1 }).Wait();
CliApp app = new CliApp(inMemoryCommentRepository, inMemoryPostRepository, inMemoryUserRepository);
app.Run();