using Maktab.Sample.Blog.Presentation.Models.Accounting;
using Maktab.Sample.Blog.Presentation.Pages.Models;
using Maktab.Sample.Blog.Service.Posts.Contracts.Commands;
using Maktab.Sample.Blog.Service.Users.Contracts.Commands;
using Mapster;

namespace Maktab.Sample.Blog.Presentation.MapsterConfiguration;

public static class MapsterConfig
{
    public static void RegisterMapping()
    {
        TypeAdapterConfig<LoginViewModel, LoginCommand>.NewConfig();
        
        TypeAdapterConfig<RegisterViewModel, RegisterCommand>.NewConfig();

        TypeAdapterConfig<UpdatePostModel, UpdatePostCommand>.NewConfig()
            .Map(dest => dest.Title, src => src.PostTitle);
    }
}