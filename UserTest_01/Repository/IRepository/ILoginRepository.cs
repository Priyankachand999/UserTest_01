namespace UserTest_01.Repository.IRepository
{
    public interface ILoginRepository
    {
        bool UserExist(int userId);
        bool UserExists(string email);

    }
}
