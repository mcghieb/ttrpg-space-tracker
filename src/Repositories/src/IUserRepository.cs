using Domain.Models;

namespace Repositories;

public interface IUserRepository
{
    Task<User?> GetUserByEmailAsync(string email);
    Task<User?> GetUserByUsernameAsync(string username);
    Task<User?> GetUserByIdAsync(Guid id);
    Task AddAsync(User user);
    Task UpdateAsync(User user);
}