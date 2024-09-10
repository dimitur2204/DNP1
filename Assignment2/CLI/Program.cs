using CLI.UI;
using InMemoryRepositories;
using RepositoryContracts;

Console.WriteLine("Initializing...");
ICommentRepository inMemoryCommentRepository = new CommentInMemoryRepository();
IPostRepository inMemoryPostRepository = new PostInMemoryRepository();
IUserRepository inMemoryUserRepository = new UserInMemoryRepository();
CliApp app = new CliApp(inMemoryCommentRepository, inMemoryPostRepository, inMemoryUserRepository);
app.Run();
