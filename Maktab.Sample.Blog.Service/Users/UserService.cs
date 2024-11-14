using Maktab.Sample.Blog.Domain.Users;
using Maktab.Sample.Blog.Service.Users.Contracts.Commands;
using Microsoft.AspNetCore.Identity;

namespace Maktab.Sample.Blog.Service.Users;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public UserService(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<bool> LoginAsync(LoginCommand command)
    {
        var result = false;
        var user = await _userManager.FindByNameAsync(command.Username);
        
        if (user != null)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(user, command.Password, false, false);
            result = signInResult.Succeeded;
        }
        
        return result;
    }
}