using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserTest_01.Model;
using UserTest_01.Repository.IRepository;

namespace UserTest_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IRegisterRepository _registerRepository;

        public UserController(IRegisterRepository registerRepository)
        {
            _registerRepository = registerRepository;
        }

        [HttpPost]
        public IActionResult CreateUser(Register user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if the user already exists
            var existingUser = _registerRepository.GetByUsername(user.Email);
            if (existingUser != null)
            {
                return Conflict("Email already exists");
            }

            // Create the user
            if (_registerRepository.CreateUser(user))
            {
                return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
            }
            else
            {
                return StatusCode(500, "Failed to create user");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _registerRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
