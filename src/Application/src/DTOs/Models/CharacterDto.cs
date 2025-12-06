namespace Application.DTOs.Models;

/// <summary>
/// Data transfer object for a Person
/// </summary>
public class CharacterDto
{
    public string Name { get; set; }
    public string Race { get; set; }
    public string Role { get; set; }
    public bool IsAlive { get; set; }
    public bool IsNpc { get; set; }
    public Guid? PartyId { get; set; }
    public Guid? ShipId { get; set; }
}