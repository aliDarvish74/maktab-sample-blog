using System.Security.Claims;
using Maktab.Sample.Blog.Presentation.Pages.Models;
using Maktab.Sample.Blog.Service.Posts;
using Maktab.Sample.Blog.Service.Posts.Contracts.Commands;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Maktab.Sample.Blog.Presentation.Pages.Posts;

public class EditPost : PageModel
{
    private readonly IPostService _postService;
    private readonly ILogger<EditPost> _logger;

    public EditPost(IPostService postService, ILogger<EditPost> logger)
    {
        _postService = postService;
        _logger = logger;
    }
    
    [BindProperty] 
    public UpdatePostModel UpdatePostModel { get; set; }
    public async Task OnGetAsync(Guid postId)
    {
        var post = await _postService.GetPostByIdAsync(postId);
        UpdatePostModel = new UpdatePostModel()
        {
            Id = post.Id,
            PostTitle = post.Title,
            PostText = post.Text
        };
    }

    public async Task<IActionResult> OnPostUpdateAsync()
    {
        if (ModelState.IsValid)
        {
            var command = UpdatePostModel.Adapt<UpdatePostCommand>();
            try
            {
                await _postService.UpdatePostAsync(command, User.Identity?.Name ?? string.Empty);
                TempData["SuccessMessage"] = "Post updated successfully.";
                return RedirectToPage("/Posts/Index");

            }
            catch (Exception e)
            {
                _logger.LogError(e,$"Something went wrong while updating post: {command.Id}");
                TempData["ErrorMessage"] = e.Message;
            }
        } 
        return Page();
    }
}