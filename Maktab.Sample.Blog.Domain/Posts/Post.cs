using Maktab.Sample.Blog.Abstraction.Domain;
using Maktab.Sample.Blog.Domain.Comments;
using Maktab.Sample.Blog.Domain.Likes;
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
    public string Title { get; private set; }
    public string PostText { get; private set; }
    public Guid AuthorId { get; private set; }
    public User Author { get; private set; }
    public List<Comment> Comments { get; private set; } = new();
    public List<Like> Likes { get; private set; } = new();
    
    protected override void Validate()
    {
        if (string.IsNullOrWhiteSpace(Title))
            throw new EmptyPostTitleException();

        if (string.IsNullOrWhiteSpace(PostText))
            throw new EmptyPostTextException();

        if (AuthorId == null || AuthorId == Guid.Empty)
            throw new EmptyAuthorIdException();
    }

    public void SetPostInfo(string title, string text)
    {
        if (!string.IsNullOrWhiteSpace(title))
            Title = title;
        
        if (!string.IsNullOrWhiteSpace(text))
            PostText = text;
    }
}