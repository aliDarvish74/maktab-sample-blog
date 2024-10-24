using Maktab.Sample.Blog.Abstraction;

namespace Maktab.Sample.Blog.Domain.Posts;

public class PostDomainException : BaseException
{
    public PostDomainException(string message, int sequence) : base(message)
    {
        Code = $"PostDomain_{sequence}";
    }
}

public class EmptyPostTitleException : PostDomainException
{
    public EmptyPostTitleException() : base("Post title can't be emtpy.", 1)
    {
    }
}
public class EmptyPostTextException : PostDomainException
{
    public EmptyPostTextException() : base("Post text can't be emtpy.", 2)
    {
    }
}