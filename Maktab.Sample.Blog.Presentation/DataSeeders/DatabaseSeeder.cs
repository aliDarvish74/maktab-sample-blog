using Maktab.Sample.Blog.Domain.Roles;
using Maktab.Sample.Blog.Domain.Users;
using Maktab.Sample.Blog.Persistence;
using Maktab.Sample.Blog.Service.Users.Contracts.Commands;
using Maktab.Sample.Blog.Service.Users.Extensions;
using Microsoft.AspNetCore.Identity;

namespace Maktab.Sample.Blog.Presentation.DataSeeders;

public class DatabaseSeeder
{
    public static async Task SeedAsync(IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();
        
        var roles = new List<Role>()
        {
            new Role { Name = "Admin" },
            new Role { Name = "Blogger" },
        };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role.Name!)) 
                await roleManager.CreateAsync(role);
        }

        var adminUser = new RegisterCommand
        {
            FirstName = "admin",
            LastName = "admin",
            Email = "blog.admin@gamil.com",
            UserName = "admin",
            Password = "admin1234",
            PhoneNumber = "09123456789"
        };
        var user = adminUser.MapToUser();
        var currentUser = await userManager.FindByNameAsync(user.UserName!); 
        if ( currentUser == null)
            await userManager.CreateAsync(user, adminUser.Password);
        
        currentUser = await userManager.FindByNameAsync(user.UserName!);
        
        if (!await userManager.IsInRoleAsync(currentUser!, "Admin"))
            await userManager.AddToRoleAsync(currentUser!, "Admin");
    }
}