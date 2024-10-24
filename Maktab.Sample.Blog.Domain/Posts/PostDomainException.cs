using Maktab.Sample.Blog.Abstraction.Exceptions;

namespace Maktab.Sample.Blog.Domain.Posts;

public class PostDomainException : BaseException
{
    public PostDomainException(string message, int sequence) : base(message)
    {
        Code = $"PostDomain_{sequence}";
    }
}



public class BaseEmptyArgumentException : PostDomainException
{
    public BaseEmptyArgumentException(string argument, int sequence) : base($"{argument} can't be emtpy.", sequence)
    {
    }
}

public class EmptyPostTitleException : BaseEmptyArgumentException
{
    public EmptyPostTitleException() : base("Post title", 1)
    {
    }
}

public class EmptyPostTextException : BaseEmptyArgumentException
{
    public EmptyPostTextException() : base("Post text", 2)
    {
    }
}
public class EmptyAuthorIdException : BaseEmptyArgumentException
{
    public EmptyAuthorIdException() : base("Author id", 3)
    {
    }
}