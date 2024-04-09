using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserTest_01.Data;
using UserTest_01.Repository.IRepository;

namespace UserTest_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IRegisterRepository _registerRepository;
        private readonly ApplicationDbContext _context;

        public LoginController(IRegisterRepository registerRepository, ApplicationDbContext context)
        {
            _registerRepository = registerRepository;
            _context = context;
        }

    }
}
