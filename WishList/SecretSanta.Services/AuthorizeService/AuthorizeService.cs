using SecretSanta.Data.EF.Repositories.UserRepository;
using SecretSanta.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta.Services.AuthorizeService
{
    public class AuthorizeService : IAuthorizeService
    {
        public AuthorizeService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User Login(string email, string password)
        {
            return _userRepository.Login(email, password);
        }

        public bool IsUserExist(string email)
        {
            return _userRepository.IsUserExist(email);
        }

        private IUserRepository _userRepository;
    }
}
