using Natural_Disasters_Web_Api.Domain.Entities;

namespace Natural_Disasters_Web_Api.Domain.Interfaces
{
    public interface IUserInterface
    {
        Task<IEnumerable<User>> GetAlluser();
        Task<User> GetUserById(int userId);
        Task<IEnumerable<User>> CreateUser(User user);
        Task<IEnumerable<User>> UpdateUser(User user);
        Task<IEnumerable<User>> DeleteUser(int userId);
    }
}
