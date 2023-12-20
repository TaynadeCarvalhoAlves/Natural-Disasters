using Natural_Disasters_Web_Api.Domain.Entities;
using Natural_Disasters_Web_Api.Domain.Interfaces;

namespace Natural_Disasters_Web_Api.Domain.Services
{
    public class UserService : IUserRepository
    {
        private readonly IUserRepository _userRepository;
        public UserService(UserService _UserService)
        {
            _userRepository = _UserService;
        }


        void IUserRepository.AddUser(User User)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(User User)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

      
    }
}
