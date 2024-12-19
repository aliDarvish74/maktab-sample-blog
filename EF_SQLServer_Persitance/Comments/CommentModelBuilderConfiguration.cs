using Maktab.Sample.Blog.Domain.Comments;
using Maktab.Sample.Blog.Domain.Posts;
using Microsoft.EntityFrameworkCore;
namespace EF_SQLServer_Persitance;


public static class CommentModelBuilderConfiguration
{
    public static void ConfigureCommentModelBuilder(this ModelBuilder builder)
    {
        builder.Entity<Comment>().HasKey(c => c.Id);

        builder.Entity<Comment>()
            .Property(c => c.CommentText)
            .HasColumnType("varchar(1000)")
            .IsRequired()
            .IsUnicode();
    }
}