using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

using Domain.Models.Game;

/// <summary>
/// Represents a user account
/// </summary>
public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required]
    public string Username { get; set; } = string.Empty;
    [Required]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string PasswordHash { get; set; } = string.Empty;
    public bool IsAdmin { get; set; } = false;
    
    // Navigation properties
    public ICollection<Party> Parties { get; set; } = new List<Party>();
    public ICollection<Player> Characters { get; set; } = new List<Player>();
}
