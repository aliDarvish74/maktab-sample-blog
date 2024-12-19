using Maktab.Sample.Blog.Domain.Users;

namespace Maktab.Sample.Blog.Service.Users.Contracts.Result;

public class UserResult
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime CreatedAt { get; set; }
}

public static class UserResultMapper
{
    public static UserResult MapToUserResult(this User user)
    {
        return new UserResult
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            CreatedAt = user.CreatedAt,
            PhoneNumber = user.PhoneNumber,
            Email = user.Email
        };
    }
}