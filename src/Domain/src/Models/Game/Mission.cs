namespace Domain.Models.Game;

public class Mission
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid? PartyId { get; set; }
    public Guid? GameId { get; set; }
    
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool Active { get; set; }
    public bool IsPublished { get; set; }
    
    // Navigation properties
    public Party? Party { get; set; }
    public Game? Game { get; set; }
}
