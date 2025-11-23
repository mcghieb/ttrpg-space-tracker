namespace Domain.Models.Game.Ship;

/// <summary>
/// Tracks current storage levels and capacity for a ship
/// </summary>
public class StorageState
{
    public int CurrentArtillery { get; set; }
    public int CurrentSupplies { get; set; }
    public int CurrentFood { get; set; }
    public int CurrentFuel { get; set; }
}
