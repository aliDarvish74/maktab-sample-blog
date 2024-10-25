using Maktab.Sample.Blog.Abstraction.Domain;
using Maktab.Sample.Blog.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maktab.Sample.Blog.Persistence.Users;

public static class UserModelBuilderConfiguration
{
    public static void ConfigureUserModelBuilder(this ModelBuilder builder)
    {
        builder.Entity<User>().HasKey(u => u.Id);
        
        /*builder.Entity<User>()
            .HasMany(u => u.Posts)
            .WithOne()
            .HasForeignKey(p => p.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);*/
        
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

/*public class BaseModelBuilderConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
    public void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(t => t.Id);
        AddMoreConfigurations(builder);
    }

    public virtual void AddMoreConfigurations(EntityTypeBuilder<T> builder)
    {
        return;
    }
}

public class UserModelBuilder : BaseModelBuilderConfiguration<User>
{
    public override void AddMoreConfigurations(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.FirstName)
            .HasColumnType("varchar(100)")
            .IsRequired()
            .IsUnicode();

        builder.Property(u => u.LastName)
            .HasColumnType("varchar(100)")
            .IsRequired()
            .IsUnicode();
    }
}*/