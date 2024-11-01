using Maktab.Sample.Blog.Abstraction;
using Maktab.Sample.Blog.Domain.Posts;
using Maktab.Sample.Blog.Domain.Users;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Maktab.Sample.Blog.Persistence.Users;

public class UserRepository : GenericRepository<User, BlogDbContext>, IUserRepository
{
    public UserRepository(BlogDbContext dbContext, ILogger<UserRepository> logger) : base(dbContext, logger)
    {
        
    }
}