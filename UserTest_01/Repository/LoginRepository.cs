using UserTest_01.Data;
using UserTest_01.Repository.IRepository;

namespace UserTest_01.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ApplicationDbContext _context;
        public LoginRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool UserExist(int userId)
        {
            return _context.Logins.Any(u => u.Id == userId);
        }

        public bool UserExists(string email)
        {
            return _context.Logins.Any(u => u.Email == email);

        }
    }
}
