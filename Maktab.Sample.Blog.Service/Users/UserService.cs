using Maktab.Sample.Blog.Domain.Posts;
using Maktab.Sample.Blog.Domain.Users;
using Maktab.Sample.Blog.Service.Users.Contracts.Result;

namespace Maktab.Sample.Blog.Service.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetUserResult>> GetUsersList()
    {
        var users = await _repository.QueryAsync(u => true);
        return users.Select(u => u.MapToUserArgs()).ToList();
    }
}