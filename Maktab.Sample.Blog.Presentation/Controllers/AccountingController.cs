
using Maktab.Sample.Blog.Presentation.Models.Accounting;
using Maktab.Sample.Blog.Service.Users;
using Maktab.Sample.Blog.Service.Users.Contracts.Commands;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Maktab.Sample.Blog.Presentation.Controllers;

public class AccountingController : Controller
{
    private readonly IUserService _userService;
    private readonly ILogger<AccountingController> _logger;

    public AccountingController(IUserService userService, ILogger<AccountingController> logger)
    {
        _userService = userService;
        _logger = logger;
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
            if (result)
            {
                TempData["SuccessMessage"] = "Logged in Successfully";
                return LocalRedirect("/Home/Index");
            }
                
            ViewData["ErrorMessage"] = "Login Failed";
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
                TempData["SuccessMessage"] = "Registration Successful";
                return LocalRedirect("/Home/index");
            }
            catch (Exception e)
            {
                _logger.LogError(e,"Something went wrong in registering new user.");
                ViewData["ErrorMessage"] = e.Message;
            }
        }
        return View("Register");
    }

    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        var username = User.Identity?.Name;
        if (!string.IsNullOrWhiteSpace(username))
        {
            try
            {
                await _userService.LogoutAsync(username);
                TempData["SuccessMessage"] = "Logout Successfully.";
            }
            catch (Exception e)
            {
                _logger.LogError(e,$"Something went wrong when trying to log out user [{username}].");
                ViewData["ErrorMessage"] = e.Message;
            }
        }
        return LocalRedirect("/Home/Index");
    }

    [HttpGet]
    public async Task<ActionResult<EditProfileModel>> EditProfile()
    {
        var user = _userService.GetByUserNameAsync(User.Identity?.Name??"");
        var res = new EditProfileModel();
        if (user != null) { 
            res = user.Adapt<EditProfileModel>();
        }
        return View(res);
    }
}