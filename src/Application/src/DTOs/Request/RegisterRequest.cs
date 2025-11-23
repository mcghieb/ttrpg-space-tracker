namespace Application.DTOs.Request;

public class RegisterRequest : AuthRequestBase
{
    public string Email { get; set; }
}