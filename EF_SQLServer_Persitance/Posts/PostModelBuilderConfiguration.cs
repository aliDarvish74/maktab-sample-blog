using Maktab.Sample.Blog.Domain.Posts;
using Microsoft.EntityFrameworkCore;

namespace EF_SQLServer_Persitance;


public static class PostModelBuilderConfiguration
{
    public static void ConfigurePostModelBuilder(this ModelBuilder builder)
    {
        builder.Entity<Post>().HasKey(p => p.Id);
        builder.Entity<Post>().HasQueryFilter(x => !x.IsDeleted);
        builder.Entity<Post>()
            .HasOne(p => p.Author)
            .WithMany(u => u.Posts)
            .HasForeignKey(p => p.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Post>()
            .HasMany(p => p.Comments)
            .WithOne()
            .HasForeignKey("PostId")
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<Post>()
            .HasMany(p => p.Likes)
            .WithOne()
            .HasForeignKey("PostId")
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