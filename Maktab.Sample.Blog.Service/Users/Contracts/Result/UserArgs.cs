using Maktab.Sample.Blog.Abstraction.Service;
using Maktab.Sample.Blog.Domain.Users;

namespace Maktab.Sample.Blog.Service.Users.Contracts.Result;

public class UserArgs : GeneralResult
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime CreatedAt { get; set; }
}

public static class UserArgsMapper
{
    public static UserArgs MapToUserArgs(this User user)
    {
        return new UserArgs
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            CreatedAt = user.CreatedAt
        };
    }
}