using Maktab.Sample.Blog.Domain.Users;
using Maktab.Sample.Blog.Service.Users.Contracts.Commands;

namespace Maktab.Sample.Blog.Service.Users.Extensions;

public static class UserModelExtensions
{
    public static User MapToUser(this RegisterCommand command)
    {
        return new User(command.FirstName, command.LastName)
        {
            Id = Guid.NewGuid(),
            UserName = command.UserName,
            Email = command.Email,
            PhoneNumber = command.PhoneNumber,
        };
    }
}