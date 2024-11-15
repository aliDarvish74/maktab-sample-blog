namespace Maktab.Sample.Blog.Service.Users.Contracts.Commands;

public class RegisterCommand
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
}
