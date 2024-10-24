using Maktab.Sample.Blog.Abstraction;

namespace Maktab.Sample.Blog.Domain.Posts;

public interface IPostRepository : IGenericRepository<Post>
{
    Task<List<Post>> SearchPostsByTitle(string title);
}