using System.Security.Claims;
using Maktab.Sample.Blog.Abstraction.Presistence;
using Maktab.Sample.Blog.Presentation.Pages.Models;
using Maktab.Sample.Blog.Service.Posts;
using Maktab.Sample.Blog.Service.Posts.Contracts.Commands;
using Maktab.Sample.Blog.Service.Posts.Contracts.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Maktab.Sample.Blog.Presentation.Pages.Posts;

[BindProperties]
public class Index : PageModel
{
    public GetPostsListResult PostsModel { get; set; }
    public Guid PostId { get; set; }
    private readonly IPostService _postService;

    public Index(IPostService postService)
    {
        _postService = postService;
    }
    public async Task OnGetAsync([FromQuery]int pageSize = 3, [FromQuery] int pageNumber = 0)
    {
        var paging = new Paging()
        {
            PageSize = pageSize,
            PageNumber = pageNumber,
        };
        PostsModel = await _postService.GetPostsListAsync(paging);
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
        return RedirectToPage("/Posts/Index");
    }
    
    public async Task<IActionResult> OnPostDeleteAsync()
    {
        var userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? Guid.Empty.ToString());

        try
        {
            await _postService.DeletePostByIdAsync(PostId, userId);
            TempData["SuccessMessage"] = "Post deleted successfully.";
        }
        catch (Exception ex)
        {
            ViewData["ErrorMessage"] = ex.Message;
        }
        
        return RedirectToPage("/Posts/Index");
    }
}