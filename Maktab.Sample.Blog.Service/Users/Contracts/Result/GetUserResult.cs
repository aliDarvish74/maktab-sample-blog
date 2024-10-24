using Maktab.Sample.Blog.Abstraction.Service;
using Maktab.Sample.Blog.Domain.Users;

namespace Maktab.Sample.Blog.Service.Users.Contracts.Result;

public class GetUserResult : GeneralResult
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime CreatedAt { get; set; }
}

public static class GetUserResultMapper
{
    public static GetUserResult MapToGetUserResult(this User user)
    {
        return new GetUserResult
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            CreatedAt = user.CreatedAt
        };
    }
}