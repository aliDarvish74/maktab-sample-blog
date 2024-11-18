using Maktab.Sample.Blog.Domain.Likes;
using Microsoft.EntityFrameworkCore;

namespace Persistanse_Ef_SqlServer;

public static class LikeModelBuilderConfiguration
{
    public static void ConfigureLikeModelBuilder(this ModelBuilder builder)
    {
        builder.Entity<Like>().HasKey(l => l.Id);
    }
}