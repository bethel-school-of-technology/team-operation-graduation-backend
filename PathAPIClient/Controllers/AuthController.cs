using PathAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using PathAPI.Models;

namespace PathAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    public static User user = new User();
    private readonly ILogger<AuthController> _logger;
    private readonly IAuthService _authService;

    public AuthController(ILogger<AuthController> logger, IAuthService service)
    {
        _logger = logger;
        _authService = service;
    }

    [HttpPost]
    [Route("register")]
    public ActionResult<User> Register(UserDto request)
    {
        user.Username = request.Username;
        user.Password = request.Password;
        user.Email = request.Email;

        _authService.CreateUser(user);
        return Ok(user);
    }
}