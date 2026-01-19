using Identity.Application.DTOs;
using Identity.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Identity.API.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly RegisterUserHandler _register;
    private readonly LoginHandler _login;

    public AuthController(
        RegisterUserHandler register,
        LoginHandler login)
    {
        _register = register;
        _login = login;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserRequest request)
    {
        await _register.HandleAsync(request);
        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var result = await _login.HandleAsync(request);
        return Ok(result);
    }
}
