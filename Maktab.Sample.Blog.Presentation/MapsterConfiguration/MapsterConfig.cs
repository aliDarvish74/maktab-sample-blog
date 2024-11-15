using Maktab.Sample.Blog.Presentation.Models.Accounting;
using Maktab.Sample.Blog.Service.Users.Contracts.Commands;
using Mapster;

namespace Maktab.Sample.Blog.Presentation.MapsterConfiguration;

public static class MapsterConfig
{
    public static void RegisterMapping()
    {
        TypeAdapterConfig<LoginViewModel, LoginCommand>.NewConfig();
        
        TypeAdapterConfig<RegisterViewModel, RegisterCommand>.NewConfig();
    }
}