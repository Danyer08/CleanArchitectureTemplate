using Application.User.Commands;
using Microsoft.AspNetCore.Mvc;

namespace API.Auth;

[Route("api/[controller]")]
[ApiController]
public class AuthController(LoginCommand loginCommand, RegisterCommand registerCommand) : ControllerBase
{
    private readonly LoginCommand _loginCommand = loginCommand;
    private readonly RegisterCommand _registerCommand = registerCommand;

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(AuthRequestDto credentials)
    {
        if (string.IsNullOrWhiteSpace(credentials.Email) || string.IsNullOrWhiteSpace(credentials.Password))
        {
            return BadRequest("Email and password are required");
        }

        var result = await _registerCommand.ExecuteAsync(credentials.Username, credentials.Email, credentials.Password);

        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(AuthRequestDto credentials)
    {
        var result = await _loginCommand.ExecuteAsync(credentials.Email, credentials.Password);

        return Ok(result);
    }
}

