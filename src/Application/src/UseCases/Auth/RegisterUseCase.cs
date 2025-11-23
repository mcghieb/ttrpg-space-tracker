using Application.DTOs.Models;
using Application.DTOs.Response;
using Application.Services;
using Domain.Models;
using Repositories;

namespace Application.UseCases.Auth;

public class RegisterUseCase(
    IUserRepository userRepository,
    IPasswordHashService passwordHashService,
    IJwtTokenService jwtTokenService)
{
    public async Task<TtrpgResponse> ExecuteAsync(string username, string password, string email)
    {
        // check if user exists
        if (await userRepository.GetUserByUsernameAsync(username) != null)
        {
            return TtrpgResponse.Failure("User already exists");
        }
        
        var passwordHash = passwordHashService.HashPassword(password);
        var user = new User
        {
            Username = username,
            Email = email,
            PasswordHash = passwordHash,
        };

        await userRepository.AddAsync(user);
        var token = jwtTokenService.GenerateToken(user.Id, user.Username, user.Email, user.IsAdmin);
        
        return AuthResponse.SuccessResult(token, DtoMapper.ToUserDto(user));
    }
}