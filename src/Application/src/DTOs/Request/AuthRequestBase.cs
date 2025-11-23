namespace Application.DTOs.Request;

public abstract class AuthRequestBase
{
    public string Username { get; set; }
    public string Password { get; set; }
}