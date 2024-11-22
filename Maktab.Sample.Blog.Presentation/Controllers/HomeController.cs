using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Maktab.Sample.Blog.Presentation.Models;
using Maktab.Sample.Blog.Service.Posts;
using Microsoft.AspNetCore.Authorization;

namespace Maktab.Sample.Blog.Presentation.Controllers;

public class HomeController : Controller
{
    private readonly IPostService _postService;
    private readonly ILogger<HomeController> _logger;

    public HomeController(IPostService postService,ILogger<HomeController> logger)
    {
        _postService = postService;
        _logger = logger;
    }
    [Authorize]
    public IActionResult Index()
    {
        return RedirectToPage("/Posts");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}