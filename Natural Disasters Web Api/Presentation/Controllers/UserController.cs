using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Natural_Disasters_Web_Api.Domain.Entities;
using Natural_Disasters_Web_Api.Domain.Interfaces;

namespace Natural_Disasters_Web_Api.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserInterface _userInterface;

        public UserController(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        [HttpGet("SearchUser")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUser()
        {
            IEnumerable<User> user = await _userInterface.GetAlluser();
            if (user == null)
            {
                return NotFound("Não há usuários registrados!");
            }

            return Ok(user);
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<IEnumerable<User>>> CreateUser(User user)
        {
            IEnumerable<User> users = await _userInterface.CreateUser(user);
            return Ok(users);

        }

        [HttpPut("UpdateUser")]
        public async Task<ActionResult<IEnumerable<User>>> UpdateUser(User user)
        {
            User registro = await _userInterface.GetUserById(user.Id);
            if (registro == null)
            {
                return NotFound("Registro não encontrado!");
            }
            IEnumerable<User> users = await _userInterface.UpdateUser(user);
            return Ok(user);

        }

        [HttpGet("SearchUserId")]
        public async Task<ActionResult<User>> GetUserById(int userId)
        {
            User user = await _userInterface.GetUserById(userId);   

            if(user == null)
            {
                return NotFound("Registro não encontrado!");
            }
            return Ok(user);
        }

    }
}
