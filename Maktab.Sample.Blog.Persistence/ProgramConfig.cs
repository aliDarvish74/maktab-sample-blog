using Maktab.Sample.Blog.Domain.Posts;
using Maktab.Sample.Blog.Domain.Roles;
using Maktab.Sample.Blog.Domain.Users;
using Maktab.Sample.Blog.Persistence.Posts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Maktab.Sample.Blog.Persistence
{
    public static class ProgramConfig
    {
        public static void AddMySQLPersistance(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<BlogDbContext>(optionsBuilder =>
                {
                    optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
                });
            services.AddScoped<IPostRepository, PostRepository>();
        }
    }
}
