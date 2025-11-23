using Application.DTOs.Models;
using Application.DTOs.Response;
using Application.Services;
using Repositories;

namespace Application.UseCases.Auth;

public class LoginUseCase(
    IUserRepository userRepository,
    IPasswordHashService passwordHashService,
    IJwtTokenService jwtTokenService)
{
    public async Task<TtrpgResponse> ExecuteAsync(string username, string password)
    {
        // Find user by username
        var user = await userRepository.GetUserByUsernameAsync(username);

        if (user == null) 
            return TtrpgResponse.Failure("Invalid username or password");

        // Verify password
        if (!passwordHashService.VerifyPassword(password, user.PasswordHash))
            return TtrpgResponse.Failure("Invalid username or password");

        // Generate JWT token
        var token = jwtTokenService.GenerateToken(
            user.Id,
            user.Username,
            user.Email,
            user.IsAdmin
        );

        var userInfo = new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            IsAdmin = user.IsAdmin
        };

        return AuthResponse.SuccessResult(token, userInfo);
    }
}
