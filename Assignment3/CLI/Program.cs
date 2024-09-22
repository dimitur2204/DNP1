using CLI.UI;
using FileRepository;
using RepositoryContracts;

Console.WriteLine("Initializing...");
ICommentRepository commentsFileRepository = new CommentsFileRepository();
IPostRepository postsFileRepository = new PostsFileRepository();
IUserRepository userFileRepository = new UserFileRepository();
CliApp app = new CliApp(commentsFileRepository, postsFileRepository, userFileRepository);
app.Run();