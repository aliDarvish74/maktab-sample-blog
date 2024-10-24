using Maktab.Sample.Blog.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Maktab.Sample.Blog.Presentation.Controllers;

public class PostController : Controller
{
    public IActionResult GetAllPosts()
    {
        return View();
    }
}