using System.ComponentModel.DataAnnotations;
using Maktab.Sample.Blog.Domain.Posts;
using Maktab.Sample.Blog.Presentation.Resources;
using Maktab.Sample.Blog.Service.Posts;
using Maktab.Sample.Blog.Service.Posts.Contracts.Commands;
using Maktab.Sample.Blog.Service.Posts.Contracts.Results;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Maktab.Sample.Blog.Presentation.Pages;

public class PostsPage : PageModel
{
    public List<PostArgs> Posts { get; set; }
    [Display(Name = "PostTitleProp", ResourceType = typeof(PresentationResources))]
    [Required(ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "RequiredValidationMessage")]
    [MinLength(5, ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "MinLengthStringValidationMessage")]
    [MaxLength(20, ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "MaxLengthStringValidationMessage")]
    public string PostTitle { get; set; }
    
    [Display(Name = "PostTextProp", ResourceType = typeof(PresentationResources))]
    [Required(ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "RequiredValidationMessage")]
    [MinLength(20, ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "MinLengthStringValidationMessage")]
    [DataType(dataType: DataType.MultilineText)]
    public string Text { get; set; }
    private readonly IPostService _postService;

    public PostsPage(IPostService postService)
    {
        _postService = postService;
    }
    public async Task OnGetAsync()
    {
        Posts = await _postService.GetAllPostsAsync(p => true);
    }

    public async Task OnPostCreateAsync()
    {

        var postCommand = new AddPostCommand
        {
            Title = PostTitle,
            PostText = Text,
            UserName = User.Identity?.Name ?? string.Empty
        };
        
        var result = await _postService.AddPostAsync(postCommand);
        await OnGetAsync();
    }
}