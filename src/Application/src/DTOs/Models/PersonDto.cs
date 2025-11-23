namespace Application.DTOs.Models;

/// <summary>
/// Data transfer object for a Person
/// </summary>
public class PersonDto(string name, string race, string role, bool isAlive, bool isNpc)
{
    public string Name { get; } = name;
    public string Race { get; } = race;
    public string Role { get; } = role;
    public bool IsAlive { get; } = isAlive;
    public bool IsNpc { get; } = isNpc;
}