using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Maktab.Sample.Blog.Presentation.Models;
using Maktab.Sample.Blog.Service.Posts;
using Maktab.Sample.Blog.Service.Posts.Contracts.Commands;

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
    public IActionResult Index()
    {
        return View();
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