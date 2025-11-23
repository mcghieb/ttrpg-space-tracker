namespace Application.Services;

public interface IPasswordHashService
{
    string HashPassword(string password);
    bool VerifyPassword(string password, string passwordHash);
}

public class PasswordHashService : IPasswordHashService
{
    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool VerifyPassword(string password, string passwordHash)
    {
        return BCrypt.Net.BCrypt.Verify(password, passwordHash);
    }
}
