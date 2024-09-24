using CLI.UI;
using FileRepository;
using RepositoryContracts;

static async Task Main(string[] args)
{
    Console.WriteLine("Initializing...");
    ICommentRepository commentsFileRepository = new CommentsFileRepository();
    IPostRepository postsFileRepository = new PostsFileRepository();
    IUserRepository userFileRepository = new UserFileRepository();
    CliApp app = new CliApp(commentsFileRepository, postsFileRepository, userFileRepository);
    await app.Run();
}

await Main(new string[]{});