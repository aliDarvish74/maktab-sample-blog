using Maktab.Sample.Blog.Abstraction.Service;
using Maktab.Sample.Blog.Abstraction.Service.Exceptions;
using Maktab.Sample.Blog.Domain.Posts;
using Maktab.Sample.Blog.Service.Posts.Contracts.Commands;
using Maktab.Sample.Blog.Service.Posts.Contracts.Results;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Maktab.Sample.Blog.Service.Configurations;
using Microsoft.Extensions.Options;

namespace Maktab.Sample.Blog.Service.Posts;

public class PostService : IPostService
{
    private readonly IPostRepository _repository;
    private readonly InternalGrantsSettings _grants;
    private readonly InternalGrantsSettings _grantsSettings;

    public PostService(IPostRepository repository,InternalGrantsSettings grants, IOptions<InternalGrantsSettings> settings)
    {
        _repository = repository;
        _grants = grants;
        _grantsSettings = settings.Value;
    }

    public async Task<GeneralResult> AddPostAsync(AddPostCommand command)
    {
        var post = new Post(command.Title, command.PostText, command.AuthorId);
        var x = _grants.Grants;
        await _repository.AddAsync(post);
        var currentServiceGrants = _grantsSettings.Grants.FirstOrDefault(g => g.ServiceName == "Bahmani");
        return new GeneralResult
        {
            Id = post.Id
        };
    }

    public async Task<List<PostArgs>> GetAllPostsAsync(Expression<Func<Post,bool>> predicate = null)
    {
        var posts = await _repository.QueryAsync(predicate ?? ( p => true), include: p => p.Include(x => x.Author)
                                                                                           .Include(x => x.Comments)
                                                                                           .Include(x => x.Likes));
        return posts.Select(p => p.MapToPostArgs()).ToList();
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

    public async Task UpdatePostAsync(UpdatePostCommand command, Guid userId)
    {
        var post = await _repository.GetAsync(command.Id, false);
        
        if(post == null)
            throw new ItemNotFoundException(nameof(Post));

        if(post.AuthorId != userId)
            throw new PermissionDeniedException();

        post.SetPostInfo(command.Title, command.PostText);

        await _repository.UpdateAsync(post);
    }
}