using SecretSanta.Data.EF.Repositories.UserRepository;
using SecretSanta.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta.Services.UserServices
{
    public class UserService : IUserService
    {
        public UserService(IUserRepository userRepositrory)
        {
            _userRepository = userRepositrory;
        }
        public void CreateUser(User user)
        {
            _userRepository.Create(user);
        }

        public void DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public User GetCurrentUser(string email)
        {
            throw new NotImplementedException();
        }

        public User GetUser(long id)
        {
            return _userRepository.Get(id);
        }

        public IEnumerable<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
        }
        private IUserRepository _userRepository;
    }
}
