using Maktab.Sample.Blog.Abstraction.Domain;
using Maktab.Sample.Blog.Domain.Posts;

namespace Maktab.Sample.Blog.Domain.Users;

public class User : BaseEntity
{
    private User()
    {
        
    }
    public User(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        Validate();
    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public List<Post> Posts { get; set; }
    protected override void Validate()
    {
        if (string.IsNullOrWhiteSpace(FirstName))
            throw new EmptyFirstNameException();

        if (string.IsNullOrWhiteSpace(LastName))
            throw new EmptyLastNameException();
    }
}