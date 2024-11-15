using Maktab.Sample.Blog.Abstraction.Exceptions;

namespace Maktab.Sample.Blog.Service.Exceptions;

public class UserServiceExceptions : BaseException
{
    public UserServiceExceptions(string message, int sequence) : base(message)
    {
        Code = "UserServiceError_" + sequence;
    }
}

public class DuplicateUserNameException : UserServiceExceptions
{
    public DuplicateUserNameException(string userName) : base($"User with given userName [{userName}] already exists.", 1)
    {
    }
}

public class RegistrationFailedException : UserServiceExceptions
{
    public RegistrationFailedException(string message) : base(message, 2)
    {
    }
}