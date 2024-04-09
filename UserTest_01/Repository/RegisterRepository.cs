using UserTest_01.Data;
using UserTest_01.Model;
using UserTest_01.Repository.IRepository;

namespace UserTest_01.Repository
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly ApplicationDbContext _context;
           public  RegisterRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool CreateUser(Register user)
        {
            _context.Registers.Add(user);
            return Save();
        }

        public ICollection<Register> GetAllUser()
        {
            return _context.Registers.ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges()==1?true:false;
        }

        Register IRegisterRepository.GetByUsername(string email)
        {
            return _context.Registers.FirstOrDefault(u => u.Email == email);
        }

        Register IRegisterRepository.GetUserById(int Id)
        {
            return _context.Registers.FirstOrDefault(u => u.Id == Id);
        }

        bool IRegisterRepository.ValidateCredentials(string email, string password)
        {
           var user=_context.Registers.FirstOrDefault(u =>u.Email == email && u.Password == password);
            return user != null;
        }
    }
}
