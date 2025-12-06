using Application.DTOs.Models;

namespace Application.DTOs.Request;

public class CreateCharacterRequest
{
   public string Token { get; set; } 
   public CharacterDto Character { get; set; }
}