using UserTest_01.Model;

namespace UserTest_01.Repository.IRepository
{
    public interface IRegisterRepository
    {
        ICollection<Register> GetAllUser();
        bool CreateUser(Register user);
        Register GetByUsername(string name);
        Register GetUserById(int Id);
        bool ValidateCredentials(string name, string password);
        bool Save();
    }
}
