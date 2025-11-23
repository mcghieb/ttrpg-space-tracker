namespace Domain.Models.Game;

using Domain.Models;

public class Game
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid GameMasterId { get; set; }
    public int CurrentCycle { get; set; }
    
    // Navigation properties
    public User GameMaster { get; set; } = null!;
    public ICollection<Party> Parties { get; set; } = new List<Party>();
    public ICollection<Mission> WorldMissionLog { get; set; } = new List<Mission>();
}
