using Application.DTOs.Models;

namespace Application.DTOs.Response;

public class AuthResponse : TtrpgResponse
{
    public UserDto? User { get; set; }

    public static AuthResponse SuccessResult(string token, UserDto user)
    {
        var loginResponse = new AuthResponse
        {
            Success = true,
            Message = "Login success.",
            Token = token,
            User = user,
        };
        return loginResponse;
    }
}

