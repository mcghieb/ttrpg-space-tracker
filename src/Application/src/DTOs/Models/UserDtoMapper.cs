using Domain.Models;

namespace Application.DTOs.Models;

public static class DtoMapper
{
    public static UserDto ToUserDto(User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Email = user.Email,
            Username = user.Username,
            IsAdmin = user.IsAdmin,
        };
    }
}