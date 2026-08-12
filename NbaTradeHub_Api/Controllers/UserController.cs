using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NbaTradeHub_Api.Core.Interfaces;
using NbaTradeHub_Api.Data.DTO;
using System.Security.Claims;

namespace NbaTradeHub_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }


        [HttpPost("login")]
        public IActionResult Login ([FromBody] UserLoginDto userRequest)
        {
            var jwt = _service.Login(userRequest.UserName, userRequest.Password);

            if (jwt == null)
                return Unauthorized("Invalid login");

            return Ok(new
            {
                token = jwt,
            });
        }


        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRegisterDto registerRequest)
        {
            var ok = _service.Register(registerRequest.UserName, registerRequest.Email, registerRequest.Password);

                if (!ok)
                return BadRequest("Användarnamn eller email finns redan");

            return Created("","Användare skapad");
        }


        [Authorize]
        [HttpPut]
        public IActionResult UpdateUser([FromBody] UserUpdateDto dto)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var ok = _service.UpdateUser(
                userId,
                dto.UserName,
                dto.Email,
                dto.Password
            );

            if (!ok)
                return NotFound("User not found");

            return Ok("Användare uppdaterad");
        }


        [Authorize]
        [HttpDelete]
        public IActionResult DeleteUser()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var ok = _service.DeleteUser(userId);

            if (!ok)
                return NotFound("User not found");

            return NoContent();
        }
    }
}
