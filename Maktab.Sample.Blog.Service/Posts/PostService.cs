using Maktab.Sample.Blog.Domain.Posts;

namespace Maktab.Sample.Blog.Service.Posts;

public class PostService : IPostService
{
    private readonly IPostRepository _repository;

    public PostService(IPostRepository repository)
    {
        _repository = repository;
    }
}