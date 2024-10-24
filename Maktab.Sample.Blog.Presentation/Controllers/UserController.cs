using Maktab.Sample.Blog.Service.Users;
using Microsoft.AspNetCore.Mvc;

namespace Maktab.Sample.Blog.Presentation.Controllers;

public class UserController : Controller
{
    private readonly IUserService _service;

    public UserController(IUserService service)
    {
        _service = service;
    }
    // GET
    public async Task<IActionResult> UsersList()
    {
        var dateTime = DateTime.Now;
        var userResults = await _service.GetUsersList();
        return View(userResults);
    }

public IActionResult UserRegistration()
    {
        return View();
    }
}