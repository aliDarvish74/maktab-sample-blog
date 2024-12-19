using Maktab.Sample.Blog.Abstraction.Presistence;
using Maktab.Sample.Blog.Domain.Posts;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;

namespace EF_SQLServer_Persitance.Posts;


public class PostRepository : GenericRepository<Post, SqlServerDbContext>, IPostRepository
{
    public PostRepository(SqlServerDbContext dbContext, ILogger<PostRepository> logger) : base(dbContext, logger)
    {
    }

    public async Task<List<Post>> SearchPostsByTitle(string title)
    {
        return await QueryAsync(p => p.Title.Contains(title));
    }

    public Task<(List<Post> items, int totalRows)> GetPostsListAsync(Paging paging, bool asNoTracking = true, Func<IQueryable<Post>, IIncludableQueryable<Post, object>> include = null)
    {
        throw new NotImplementedException();
    }
}