namespace Domain.Models.Game.Ship;

/// <summary>
/// Defines maintenance requirements for a ship class
/// </summary>
public class MaintenanceInfo
{
    /// <summary>
    /// Hours of operation before maintenance is required
    /// </summary>
    public int MaintenanceInterval { get; set; }
    
    /// <summary>
    /// Supplies consumed per maintenance cycle
    /// </summary>
    public int SupplyCostPerMaintenance { get; set; }
}
