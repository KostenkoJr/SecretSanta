using SecretSanta.Data.EF.Repositories.UserRepository;
using SecretSanta.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
            var user = _userRepository.GetCurrentUser(email);
            if(user != null)
            {
                var salt = user.Salt;
                var hashedPassword = HashPassword(password, salt);
                return _userRepository.Login(email, hashedPassword);
            }
            return null;
        }

        public bool IsUserExist(string email)
        {
            return _userRepository.IsUserExist(email);
        }
        public void RegisterUser(User user)
        {
            var creds = FirstHashPassword(user.Password);
            user.Password = creds.Password;
            user.Salt = creds.Salt;
            _userRepository.Create(user);
        }

        /// <summary>
        /// Used to generate salt and hash the user password during registration
        /// </summary>
        /// <param name="userPassword">User password</param>
        /// <returns></returns>
        private Creds FirstHashPassword(string userPassword)
        {
            Rfc2898DeriveBytes PBKDF2 = new Rfc2898DeriveBytes(userPassword, 8, 1000);    //Hash the password with a 8 byte salt
            byte[] hashedPassword = PBKDF2.GetBytes(20);
            byte[] salt = PBKDF2.Salt;
            var creds = new Creds
            {
                Password = Convert.ToBase64String(hashedPassword),
                Salt = Convert.ToBase64String(salt)
            };
            return creds;
        }

        private String HashPassword(string userPassword, string userSalt)
        {
            Rfc2898DeriveBytes PBKDF2 = new Rfc2898DeriveBytes(userPassword, Convert.FromBase64String(userSalt), 1000);
            return Convert.ToBase64String(PBKDF2.GetBytes(20));
        }

        public bool ChangePassword(User user, string oldPassword, string newPassword)
        {
            oldPassword = HashPassword(oldPassword, user.Salt);
            if (user.Password == oldPassword)
            {
                user.Password = HashPassword(newPassword, user.Salt);
                _userRepository.Update(user);
                return true;
            }
            return false;
        }

        private struct Creds
        {
            public string Password { get; set; }
            public string Salt { get; set; }
        }

        private IUserRepository _userRepository;
    }
}
