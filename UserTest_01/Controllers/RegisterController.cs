using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using UserTest_01.Data;
using UserTest_01.Model;
using UserTest_01.Repository.IRepository;

namespace UserTest_01.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterRepository _registerRepository;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;

        public RegisterController(IRegisterRepository registerRepository, ApplicationDbContext context,IConfiguration config )
        {
            _registerRepository = registerRepository;
            _context = context;
            _config = config;
        }
        [HttpPost("register")]
        public IActionResult Register(Register user)
        {
            Register newUser = new Register()
            {
                Name = user.Name,
                Address = user.Address,
                Email = user.Email, 
                Password= user.Password,
                CoinfirmPassword= user.CoinfirmPassword,
                Role = "admin"
                            
            }; 
            if (_registerRepository.GetByUsername(user.Email) != null)
            {
                return Conflict("Email already exists");
            }

            _registerRepository.CreateUser(newUser);
            return Ok("User successfully registered");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Login user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_registerRepository.ValidateCredentials(user.Email, user.Password))
            {
                return Unauthorized("Invalid username or password");
            }
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

            return Ok(token);

            //return Ok("Login successful");
        }
        [HttpPost("validtoken")]
        public IActionResult ValidateToken([FromBody] TokenRequest tokenRequest)
        {
            var token = tokenRequest.Token;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                return Ok(new { isValid = true });
            }
            catch
            {
                return Unauthorized(new { error = "Invalid token" });
            }
        }
    


    [HttpGet]
        public IActionResult GetAllUser() 
        {
            ICollection<Register> users = _context.Registers.ToList();
            return Ok(users);
        }
    }
}
