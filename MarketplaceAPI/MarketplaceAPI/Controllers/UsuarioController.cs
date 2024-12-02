using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MarketplaceAPI.Models;
using MarketplaceAPI.Services.Interfaces;


namespace MarketplaceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await _userService.ListarUsuarios();
            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userService.ObtenerUsuario(id);
            if (user == null)
                return NotFound($"User with ID {id} not found.");

            return Ok(user);
        }

        [HttpGet("email/{email}")]
        public async Task<ActionResult<User>> GetUserByEmail(string email)
        {
            var user = await _userService.ObtenerUsuarioConEmail(email);
            if (user == null)
                return NotFound($"User with email {email} not found.");

            return Ok(user);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<User>> UpdateUser(int id, [FromBody] User updatedUser)
        {
            if (id != updatedUser.IdUser)
                return BadRequest("User ID mismatch.");

            var user = await _userService.ObtenerUsuario(id);
            if (user == null)
                return NotFound($"User with ID {id} not found.");

            var result = await _userService.ActualizarUsuario(updatedUser);
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = await _userService.ObtenerUsuario(id);
            if (user == null)
                return NotFound($"User with ID {id} not found.");

            await _userService.EliminarUsuario(id);
            return NoContent();
        }
    }
}
