using Maktab.Sample.Blog.Abstraction.Domain;
using Maktab.Sample.Blog.Domain.Users;

namespace Maktab.Sample.Blog.Domain.Posts;

public class Post : BaseEntity
{
    public Post(string title, string postText, Guid authorId)
    {
        Title = title;
        PostText = postText;
        AuthorId = authorId;
        Validate();
    }
    public string Title { get; set; }
    public string PostText { get; set; }
    public Guid AuthorId { get; set; }
    public User Author { get; set; }
    
    protected override void Validate()
    {
        if (string.IsNullOrWhiteSpace(Title))
            throw new EmptyPostTitleException();

        if (string.IsNullOrWhiteSpace(PostText))
            throw new EmptyPostTextException();

        if (AuthorId == null || AuthorId == Guid.Empty)
            throw new EmptyAuthorIdException();
    }
}