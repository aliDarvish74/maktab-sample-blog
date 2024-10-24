using Maktab.Sample.Blog.Domain.Posts;
using Maktab.Sample.Blog.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Maktab.Sample.Blog.Persistence.Posts;

public class PostRepository : GenericRepository<Post>, IPostRepository
{
    public PostRepository(BlogDbContext dbContext, ILogger<PostRepository> logger) : base(dbContext, logger)
    {
    }

    public async Task<List<Post>> SearchPostsByTitle(string title)
    {
        return await QueryAsync(p => p.Title.Contains(title));
    }
}