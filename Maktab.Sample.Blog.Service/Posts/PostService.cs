using Maktab.Sample.Blog.Abstraction.Service;
using Maktab.Sample.Blog.Abstraction.Service.Exceptions;
using Maktab.Sample.Blog.Domain.Posts;
using Maktab.Sample.Blog.Service.Posts.Contracts.Commands;
using Maktab.Sample.Blog.Service.Posts.Contracts.Results;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Maktab.Sample.Blog.Abstraction.Presistence;
using Maktab.Sample.Blog.Domain.Users;
using Maktab.Sample.Blog.Service.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Maktab.Sample.Blog.Service.Posts;

public class PostService : IPostService
{
    private readonly IPostRepository _repository;
    private readonly UserManager<User> _userManager;
    private readonly InternalGrantsSettings _grants;
    private readonly InternalGrantsSettings _grantsSettings;

    public PostService(IPostRepository repository,UserManager<User> userManager,InternalGrantsSettings grants, IOptions<InternalGrantsSettings> settings)
    {
        _repository = repository;
        _userManager = userManager;
        _grants = grants;
        _grantsSettings = settings.Value;
    }

    public async Task<GeneralResult> AddPostAsync(AddPostCommand command)
    {
        var user = await _userManager.FindByNameAsync(command.UserName);
        if (user == null)
            throw new ItemNotFoundException(nameof(User));
        
        var post = new Post(command.Title, command.PostText, user.Id);
        await _repository.AddAsync(post);
        return new GeneralResult
        {
            Id = post.Id
        };
    }

    public async Task DeletePostByIdAsync(Guid id, Guid userId)
    {
        if (id == Guid.Empty)
            throw new InvalidOperationException("Id is not valid.");

        var post = await _repository.GetAsync(id);

        if (post == null)
            throw new ItemNotFoundException(nameof(Post));

        if (post.AuthorId != userId)
            throw new PermissionDeniedException();

        await _repository.SoftDeleteAsync(id);
    }

    public async Task<GetPostsListResult> GetPostsListAsync(Paging paging)
    {
        var result = await _repository.GetPostsListAsync(paging , include: p => p.Include(x => x.Author)
                                                                                           .Include(x => x.Comments)
                                                                                           .Include(x => x.Likes));
        var items = result.items.Select(p => p.MapToPostArgs()).ToList();
        return new GetPostsListResult(items, result.totalRows, paging);
    }

    public async Task<PostArgs> GetPostByIdAsync(Guid id)
    {
        var post = await _repository.GetAsync(id,
            include: p => p.Include(x => x.Author)
            .Include(x => x.Comments)
            .Include(x => x.Likes));

        if (post == null)
            throw new ItemNotFoundException(nameof(Post));

        return post.MapToPostArgs();
    }

    public async Task UpdatePostAsync(UpdatePostCommand command, string userName)
    {
        var post = await _repository.GetAsync(command.Id, false);
        var user = await _userManager.FindByNameAsync(userName);
        if (user == null)
            throw new ItemNotFoundException(nameof(User));
        
        if(post == null)
            throw new ItemNotFoundException(nameof(Post));

        if(post.AuthorId != user.Id)
            throw new PermissionDeniedException();

        post.SetPostInfo(command.Title, command.PostText);

        await _repository.UpdateAsync(post);
    }
}