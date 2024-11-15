using Maktab.Sample.Blog.Domain.Users;
using Maktab.Sample.Blog.Service.Exceptions;
using Maktab.Sample.Blog.Service.Users.Contracts.Commands;
using Maktab.Sample.Blog.Service.Users.Extensions;
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
        var user = await _userManager.FindByNameAsync(command.UserName);
        
        if (user != null)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(user, command.Password, false, false);
            result = signInResult.Succeeded;
        }
        
        return result;
    }

    public async Task<bool> RegisterAsync(RegisterCommand command)
    {
        var duplicateUser = await _userManager.FindByNameAsync(command.UserName);
        if (duplicateUser != null)
            throw new DuplicateUserNameException(command.UserName);
        
        var user = command.MapToUser();
        var registerResult = await _userManager.CreateAsync(user, command.Password);
        
        if (!registerResult.Succeeded)
            throw new RegistrationFailedException(registerResult.Errors.FirstOrDefault()?.Description ?? "Registration failed");
        
        return registerResult.Succeeded;
    }
}