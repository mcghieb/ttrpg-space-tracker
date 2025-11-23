using System.Linq.Expressions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories;

public class UserRepository : IUserRepository
{
    private readonly TtrpgDbContext _dbContext;

    public UserRepository(TtrpgDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<User?> GetUserByEmailAsync(string email) =>
        GetUserAsync(u => u.Email == email);

    public Task<User?> GetUserByUsernameAsync(string username) =>
        GetUserAsync(u => u.Username == username);

    public Task<User?> GetUserByIdAsync(Guid id) =>
        GetUserAsync(u => u.Id == id);

    private Task<User?> GetUserAsync(Expression<Func<User, bool>> predicate)
    {
        return _dbContext.Set<User>().FirstOrDefaultAsync(predicate);
    }

    public Task AddAsync(User user) =>
        SaveEntityAsync(set => set.Add(user));

    public Task UpdateAsync(User user) => 
        SaveEntityAsync(set => set.Update(user));

    private async Task SaveEntityAsync(Action<DbSet<User>> action)
    {
        action(_dbContext.Set<User>());
        await _dbContext.SaveChangesAsync();
    }
}