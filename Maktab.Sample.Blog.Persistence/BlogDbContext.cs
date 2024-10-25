using System.Reflection;
using Maktab.Sample.Blog.Domain.Comments;
using Maktab.Sample.Blog.Domain.Likes;
using Maktab.Sample.Blog.Domain.Posts;
using Maktab.Sample.Blog.Domain.Users;
using Maktab.Sample.Blog.Persistence.Comments;
using Maktab.Sample.Blog.Persistence.Likes;
using Maktab.Sample.Blog.Persistence.Posts;
using Maktab.Sample.Blog.Persistence.Users;
using Microsoft.EntityFrameworkCore;

namespace Maktab.Sample.Blog.Persistence;

public class BlogDbContext : DbContext
{
    public BlogDbContext()
    {
        
    }
    public BlogDbContext(DbContextOptions<BlogDbContext> dbContext) : base(dbContext)
    {
        
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<Comment> Comments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var conStr =
                "server=localhost; port=3006; database=MaktabBlogDb; user=root; password=root; Persist Security Info=False; Connect Timeout=300";
            optionsBuilder.UseMySql(conStr, ServerVersion.AutoDetect(conStr));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        /*modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());*/
        modelBuilder.ConfigureUserModelBuilder();
        modelBuilder.ConfigurePostModelBuilder();
        modelBuilder.ConfigureCommentModelBuilder();
        modelBuilder.ConfigureLikeModelBuilder();
    }
}