using Maktab.Sample.Blog.Service.Users.Contracts.Result;

namespace Maktab.Sample.Blog.Service.Users;

public interface IUserService
{
    Task<List<GetUserResult>> GetUsersList();
}