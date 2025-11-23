namespace Application.DTOs.Response;

public class TtrpgResponse
{
    public bool Success { get; set; }
    public string? Token { get; set; }
    public string? Message { get; set; }
    
    public static TtrpgResponse Failure(string message)
    {
        var response = new TtrpgResponse
        {
            Success = false,
            Message = message
        };
        return response;
    }
}