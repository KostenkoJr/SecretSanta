using SecretSanta.Data.EF.Repositories.RecipientRepository;
using SecretSanta.Data.EF.Repositories.UserRepository;
using SecretSanta.Data.Models;
using SecretSanta.Services.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta.Services.UserServices
{
    public class UserService : IUserService
    {
        public UserService(IUserRepository userRepositrory, IRecipientRepository recipientRepository)
        {
            _recipientRepository = recipientRepository;
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
            return _userRepository.GetCurrentUser(email);
        }

        public User GetUser(long id)
        {
            return _userRepository.Get(id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _userRepository.Get();
        }

        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
        }
        public void SetRecipient()
        {
            var users = _userRepository.Get().ToList();
            users.Mix();
            _recipientRepository.SetRecipientForUsers(users);
        }
        private IUserRepository _userRepository;
        private IRecipientRepository _recipientRepository;
    }
}
