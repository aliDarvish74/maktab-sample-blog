using Maktab.Sample.Blog.Domain.Posts;
using Microsoft.EntityFrameworkCore;

namespace Maktab.Sample.Blog.Persistence.Posts;

public static class PostModelBuilderConfiguration
{
    public static void ConfigurePostModelBuilder(this ModelBuilder builder)
    {
        builder.Entity<Post>().HasKey(p => p.Id);

        builder.Entity<Post>()
            .HasOne(p => p.Author)
            .WithMany(u => u.Posts)
            .HasForeignKey(p => p.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<Post>()
            .Property(u => u.Title)
            .HasColumnType("varchar(200)")
            .IsRequired()
            .IsUnicode();
        
        builder.Entity<Post>()
            .Property(u => u.PostText)
            .HasColumnType("text")
            .IsRequired()
            .IsUnicode();
    }
}