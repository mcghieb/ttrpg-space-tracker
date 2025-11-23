namespace Domain.Models.Game.Ship;

/// <summary>
/// Blueprint/template defining a class of ship with base specifications.
/// Think of this as the "Corvette Class" or "Dreadnought Class" - the design,
/// not an individual vessel.
/// </summary>
public class ShipClassification
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    public int CrewCapacity { get; set; }
    public StorageCapacity StorageCapacity { get; set; } = new();
    public int Speed { get; set; }
    public int WeaponDamage { get; set; }
    public float ShieldStrength { get; set; }
    public MaintenanceInfo MaintenanceInfo { get; set; } = new();
    
    // Navigation properties
    public ICollection<Ship> Ships { get; set; } = new List<Ship>();
}
