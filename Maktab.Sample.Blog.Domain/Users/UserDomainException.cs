using Maktab.Sample.Blog.Abstraction;

namespace Maktab.Sample.Blog.Domain.Users;

public class UserDomainException : BaseException
{
    public UserDomainException(string message, int sequence) : base(message)
    {
        Code = $"UserDomain_{sequence}";
    }
}

public class EmptyFirstNameException : UserDomainException
{
    public EmptyFirstNameException() : base("User first name can't be empty", 1)
    {
    }
}
public class EmptyLastNameException : UserDomainException
{
    public EmptyLastNameException() : base("User last name can't be empty", 2)
    {
    }
}