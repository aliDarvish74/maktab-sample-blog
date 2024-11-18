using Maktab.Sample.Blog.Service.Users.Contracts.Commands;
using Maktab.Sample.Blog.Service.Users.Contracts.Result;

namespace Maktab.Sample.Blog.Service.Users;

public interface IUserService
{
    Task<bool> LoginAsync(LoginCommand command);
    Task<bool> RegisterAsync(RegisterCommand command);
    Task LogoutAsync(string username);
    Task<UserArgs> GetByUserNameAsync(string userName);
    Task<UserResult> GetFullByUserNameAsync(string userName);
    Task<bool> UpdateAsync(UserCommand command,string userName);
}