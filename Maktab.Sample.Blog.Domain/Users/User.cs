using Maktab.Sample.Blog.Domain.Comments;
using Maktab.Sample.Blog.Domain.Likes;
using Maktab.Sample.Blog.Domain.Posts;
using Microsoft.AspNetCore.Identity;

namespace Maktab.Sample.Blog.Domain.Users;

public class User : IdentityUser<Guid>
{
    private User()
    {
    }
    public User(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public List<Post> Posts { get; set; } = new();
    public List<Comment> Comments { get; set; } = new();
    public List<Like> Likes { get; set; } = new();

    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
}