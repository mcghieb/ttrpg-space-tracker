using Application.DTOs.Request;
using Application.UseCases.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/character")]
public class CharacterController
{
   [HttpPost]
   public async Task<IActionResult> Create([FromBody] CreateCharacterRequest request)
   {
       if (request.Token == null)
       {
           return Unauthorized(new { message = "Token is required"});
       }
       
       var requiredStrings = new List<string>
       {
           request.Character.Name, request.Character.Role, request.Character.Race
       };
       if (requiredStrings.Any(string.IsNullOrEmpty))
       {
           return BadRequest(new { message = "Role, Name, and Race are required" });
       }

       var requiredBools = new List<bool> { request.Character.IsAlive, request.Character.IsNpc };
       if (requiredBools.Contains(false))
       {
           return BadRequest(new { message = "IsAlive and IsNpc are required"});
       }

       var result = await CreateCharacterUseCase.ExecuteAsync();
       if (!result.Success)
       {
           return InternalServerError(new { message = result.Message });
       }

       return Ok(result);
   }
}