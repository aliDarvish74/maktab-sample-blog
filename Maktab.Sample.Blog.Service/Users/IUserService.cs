using Maktab.Sample.Blog.Service.Users.Contracts.Commands;

namespace Maktab.Sample.Blog.Service.Users;

public interface IUserService
{
    Task<bool> LoginAsync(LoginCommand command);
    Task<bool> RegisterAsync(RegisterCommand command);
    Task LogoutAsync(string username);
}