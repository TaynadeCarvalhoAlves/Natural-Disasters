using Natural_Disasters_Web_Api.Domain.Entities;

namespace Natural_Disasters_Web_Api.Domain.Interfaces
{
    public interface IUserRepository
    {
        void AddUser(User User);
        List<User> GetAll();
        void DeleteUser(User User);
    }
}
