using Maktab.Sample.Blog.Domain.Posts;
using Maktab.Sample.Blog.Persistence;
using Microsoft.Extensions.Logging;
namespace EF_SQLServer_Persitance;


public class PostRepository : GenericRepository<Post, SqlServerDbContext>, IPostRepository
{
    public PostRepository(SqlServerDbContext dbContext, ILogger<PostRepository> logger) : base(dbContext, logger)
    {
    }

    public async Task<List<Post>> SearchPostsByTitle(string title)
    {
        return await QueryAsync(p => p.Title.Contains(title));
    }
}