using Maktab.Sample.Blog.Abstraction;
using Maktab.Sample.Blog.Domain.Users;
using Microsoft.Extensions.Logging;

namespace Maktab.Sample.Blog.Persistence.Users;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(BlogDbContext dbContext, ILogger<GenericRepository<User>> logger) : base(dbContext, logger)
    {
    }
}