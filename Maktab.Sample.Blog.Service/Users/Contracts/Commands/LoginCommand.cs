namespace Maktab.Sample.Blog.Service.Users.Contracts.Commands;

public class LoginCommand
{
    public string UserName { get; set; }
    public string Password { get; set; }
}