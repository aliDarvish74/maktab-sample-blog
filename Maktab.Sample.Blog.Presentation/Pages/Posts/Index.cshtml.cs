using System.ComponentModel.DataAnnotations;
using Maktab.Sample.Blog.Presentation.Resources;
using Maktab.Sample.Blog.Service.Posts;
using Maktab.Sample.Blog.Service.Posts.Contracts.Commands;
using Maktab.Sample.Blog.Service.Posts.Contracts.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Maktab.Sample.Blog.Presentation.Pages.Posts;

[BindProperties]
public class Index : PageModel
{
    public List<PostArgs> PostsModel { get; set; }
    
    private readonly IPostService _postService;

    public Index(IPostService postService)
    {
        _postService = postService;
    }
    public async Task OnGetAsync()
    {
        PostsModel = await _postService.GetAllPostsAsync(p => true);
    }
    
    public AddPostModel AddPostModel { get; set; }
    public async Task<IActionResult> OnPostCreateAsync()
    {
        var postCommand = new AddPostCommand
        {
            Title = AddPostModel.PostTitle,
            PostText = AddPostModel.PostText,
            UserName = User.Identity?.Name ?? string.Empty
        };
        
        var result = await _postService.AddPostAsync(postCommand);
        return RedirectToPage("/PostsModel");
    }
}

public class AddPostModel
{
    [Display(Name = "PostTitleProp", ResourceType = typeof(PresentationResources))]
    [Required(ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "RequiredValidationMessage")]
    [MinLength(5, ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "MinLengthStringValidationMessage")]
    [MaxLength(30, ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "MaxLengthStringValidationMessage")]
    public string PostTitle { get; set; }
    
    [Display(Name = "PostTextProp", ResourceType = typeof(PresentationResources))]
    [Required(ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "RequiredValidationMessage")]
    [MinLength(20, ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "MinLengthStringValidationMessage")]
    [DataType(DataType.MultilineText)]
    public string PostText { get; set; }
}