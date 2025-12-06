namespace Domain.Models.Game;

using ShipEntity = Domain.Models.Game.Ship.Ship;

/// <summary>
/// Base class for characters (NPCs and Players)
/// </summary>
public abstract class Character
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid? PartyId { get; set; }
    public Guid? ShipId { get; set; }
    
    public string Name { get; set; } = string.Empty;
    public string Race { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public bool IsAlive { get; set; } = true;
    
    // Navigation properties
    public Party? Party { get; set; } = null!;
    public ShipEntity? Ship { get; set; }
}

/// <summary>
/// Non-player character
/// </summary>
public class Npc : Character
{
}

/// <summary>
/// Player character - linked to a User
/// </summary>
public class Player : Character
{
    public Guid UserId { get; set; }
    
    // Navigation property
    public User User { get; set; } = null!;
}
