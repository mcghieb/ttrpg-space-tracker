namespace Domain.Models.Game.Ship;

/// <summary>
/// Defines the maximum storage capacity for various resource types
/// </summary>
public class StorageCapacity
{
    public int ArtilleryCapacity { get; set; }
    public int SuppliesCapacity { get; set; }
    public int FoodCapacity { get; set; }
    public int FuelCapacity { get; set; }
}
