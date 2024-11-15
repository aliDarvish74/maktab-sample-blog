using Maktab.Sample.Blog.Presentation.Models.Accounting;
using Maktab.Sample.Blog.Service.Users;
using Maktab.Sample.Blog.Service.Users.Contracts.Commands;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Maktab.Sample.Blog.Presentation.Controllers;

public class AccountingController : Controller
{
    private readonly IUserService _userService;

    public AccountingController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost()]
    public async Task<IActionResult> LoginPostAsync(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _userService.LoginAsync(model.Adapt<LoginCommand>());
            if(result)
                return RedirectToAction("Index", "Home");
                
            ViewData["Message"] = "Login Failed";
        }
        return View("Login");
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> RegisterPostAsync(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var result = await _userService.RegisterAsync(model.Adapt<RegisterCommand>());
                return LocalRedirect("/Home/index");
            }
            catch (Exception e)
            {
                ViewData["Message"] = e.Message;
            }
            
        }

        return View("Register");
    }
}