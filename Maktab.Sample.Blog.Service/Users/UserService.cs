using Maktab.Sample.Blog.Domain.Posts;
using Maktab.Sample.Blog.Domain.Users;
using Maktab.Sample.Blog.Service.Users.Contracts.Result;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Maktab.Sample.Blog.Service.Users;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;

    public UserService(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<List<UserArgs>> GetUsersList()
    {
        var users = await _userManager.Users.ToListAsync();
        return users.Select(u => u.MapToUserArgs()).ToList();
    }
}