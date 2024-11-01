using Maktab.Sample.Blog.Abstraction.Service;
using Maktab.Sample.Blog.Domain.Comments;
using Maktab.Sample.Blog.Service.Users.Contracts.Result;

namespace Maktab.Sample.Blog.Service.Comments.Contracts.Results;

public class CommentArgs : GeneralResult
{
    public string CommentText { get; set; }
    public UserArgs? Author { get; set; }
}

public static class CommentArgsMapper
{
    public static CommentArgs MapToCommentArgs(this Comment comment)
    {
        return new CommentArgs
        {
            Id = comment.Id,
            CommentText = comment.CommentText,
            Author = comment.Author?.MapToUserArgs(),
        };
    }
}
