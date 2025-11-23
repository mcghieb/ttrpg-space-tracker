namespace Domain.Models.Game.Ship;

using Domain.Models.Game;

public class Ship
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid PartyId { get; set; }
    public Guid ShipClassificationId { get; set; }
    
    public MaintenanceInfo MaintenanceInfo { get; set; } = new();
    public StorageState CurrentStorageState { get; set; } = new();
    
    // Navigation properties
    public Party Party { get; set; } = null!;
    public ShipClassification Classification { get; set; } = null!;
    public ICollection<Character> Crew { get; set; } = new List<Character>();
}
