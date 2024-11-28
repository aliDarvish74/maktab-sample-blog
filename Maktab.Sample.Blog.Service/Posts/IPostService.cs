using Maktab.Sample.Blog.Abstraction.Service;
using Maktab.Sample.Blog.Domain.Posts;
using Maktab.Sample.Blog.Service.Posts.Contracts.Commands;
using Maktab.Sample.Blog.Service.Posts.Contracts.Results;
using System.Linq.Expressions;

namespace Maktab.Sample.Blog.Service.Posts;

public interface IPostService
{
    Task<GeneralResult> AddPostAsync(AddPostCommand command);
    Task UpdatePostAsync(UpdatePostCommand command, string userName);
    Task<PostArgs> GetPostByIdAsync(Guid id);
    Task DeletePostByIdAsync(Guid id, Guid userId);
    Task<List<PostArgs>> GetAllPostsAsync(Expression<Func<Post, bool>> predicate);
}