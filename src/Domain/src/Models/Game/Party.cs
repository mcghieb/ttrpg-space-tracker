namespace Domain.Models.Game;

using ShipEntity = Domain.Models.Game.Ship.Ship;

public class Party
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid GameId { get; set; }
    
    // Navigation properties
    public Game Game { get; set; } = null!;
    public ICollection<Character> Characters { get; set; } = new List<Character>();
    public ICollection<User> Users { get; set; } = new List<User>();
    public ICollection<ShipEntity> Ships { get; set; } = new List<ShipEntity>();
    public ICollection<Mission> MissionLog { get; set; } = new List<Mission>();
}
