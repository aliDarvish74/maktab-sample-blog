using Maktab.Sample.Blog.Abstraction.Domain;
using Maktab.Sample.Blog.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Domain.Comments;

public class Comment : BaseEntity
{
    public Comment(string commentText/*, Guid authorId, Guid postId*/)
    {
        CommentText = commentText;
        /*AuthorId = authorId;
        PostId = postId;*/
    }

    public string CommentText { get; set; }
    public Guid AuthorId { get; set; }
    public User Author { get; set; }

    protected override void Validate()
    {
        if(string.IsNullOrWhiteSpace(CommentText))
        {
            throw new Exception("Comment txt can't be empty.");
        }
    }
}
