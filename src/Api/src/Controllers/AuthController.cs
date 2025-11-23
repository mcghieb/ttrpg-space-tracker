using Application.UseCases.Auth;
using Application.DTOs.Request;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(LoginUseCase loginUseCase, RegisterUseCase registerUseCase) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
        {
            return BadRequest(new { message = "Username and password are required" });
        }

        var result = await loginUseCase.ExecuteAsync(request.Username, request.Password);

        if (!result.Success)
        {
            return Unauthorized(new { message = result.Message });
        }

        return Ok(result);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Username)
                                                     || string.IsNullOrWhiteSpace(request.Password))
        {
            return BadRequest(new { message = "Username, email, and password are required" });
        }
        
        var result = await registerUseCase.ExecuteAsync(request.Username, request.Password, request.Email);

        if (!result.Success)
        {
            return BadRequest(new { message = result.Message });
        }
        
        return Ok(result);
    }
}
