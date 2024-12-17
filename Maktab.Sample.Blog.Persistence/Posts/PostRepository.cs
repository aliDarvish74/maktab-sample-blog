using Maktab.Sample.Blog.Abstraction.Presistence;
using Maktab.Sample.Blog.Domain.Posts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;

namespace Maktab.Sample.Blog.Persistence.Posts;

public class PostRepository : GenericRepository<Post, BlogDbContext>, IPostRepository
{
    public PostRepository(BlogDbContext dbContext, ILogger<PostRepository> logger) : base(dbContext, logger)
    {
    }

    public async Task<List<Post>> SearchPostsByTitle(string title)
    {
        return await QueryAsync(p => p.Title.Contains(title));
    }

    public async Task<(List<Post> items, int totalRows)> GetPostsListAsync(Paging paging, bool asNoTracking = true, Func<IQueryable<Post>, IIncludableQueryable<Post, object>> include = null)
    {
        var query = GenerateQuery(asNoTracking, include);
        var totalRows = await query.CountAsync();
        var result = await query.OrderByDescending(p => p.CreatedAt).Skip(paging.Skip()).Take(paging.PageSize).ToListAsync();
        return (result, totalRows);
    }
}