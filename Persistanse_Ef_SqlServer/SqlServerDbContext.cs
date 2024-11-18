using Maktab.Sample.Blog.Domain.Comments;
using Maktab.Sample.Blog.Domain.Likes;
using Maktab.Sample.Blog.Domain.Posts;
using Maktab.Sample.Blog.Domain.Roles;
using Maktab.Sample.Blog.Domain.Users;
using Maktab.Sample.Blog.Persistence.Comments;
using Maktab.Sample.Blog.Persistence.Likes;
using Maktab.Sample.Blog.Persistence.Posts;
using Maktab.Sample.Blog.Persistence.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Persistanse_Ef_SqlServer
{
    internal class SqlServerDbContext : IdentityDbContext<User, Role, Guid>
    {
        public SqlServerDbContext()
        {

        }
        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> dbContext) : base(dbContext)
        {

        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var conStr =
                  "Data Source=.\\SQLEXPRESS;Initial Catalog=blogdb;TrustServerCertificate=True;Integrated Security=SSPI";
                optionsBuilder.UseSqlServer(conStr);
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
}
