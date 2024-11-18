using Maktab.Sample.Blog.Abstraction.Domain;
using Maktab.Sample.Blog.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistanse_Ef_SqlServer;


public static class UserModelBuilderConfiguration
{
    public static void ConfigureUserModelBuilder(this ModelBuilder builder)
    {
        builder.Entity<User>().HasKey(u => u.Id);
        
        
        builder.Entity<User>()
            .Property(u => u.FirstName)
            .HasColumnType("varchar(100)")
            .IsRequired()
            .IsUnicode();
        
        builder.Entity<User>()
            .Property(u => u.LastName)
            .HasColumnType("varchar(100)")
            .IsRequired()
            .IsUnicode();

        builder.Entity<User>()
            .HasMany(u => u.Comments)
            .WithOne(c => c.Author)
            .HasForeignKey(c => c.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<User>()
            .HasMany(u => u.Likes)
            .WithOne()
            .HasForeignKey("UserId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}

