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
            users[users.Count() - 1].RecipientId = users[0].Id;
            _userRepository.Update(users[users.Count() - 1]);
            for (int i = 0; i < users.Count() - 1; i++)
            {
                users[i].RecipientId = users[i + 1].Id;
                _userRepository.Update(users[i]);
            }
           
        }
        //public void SetRecipientForUsers(List<User> users)
        //{
        //    using (SantaContext context = new SantaContext())
        //    {
        //        users[users.Count() - 1].RecipientId = users[0].Id;

        //        for (int i = 0; i < users.Count() - 1; i++)
        //        {
        //            context.Users.Attach(users[i]);
        //            users[i].RecipientId = users[i + 1].Id;
        //            users[i].Recipient = users[i + 1];
        //            //CreateRecipient(new Recipient
        //            //{
        //            //    Id = users[i + 1].Id,
        //            //    FirstName = users[i + 1].FirstName,
        //            //    LastName = users[i + 1].LastName,
        //            //    Email = users[i + 1].Email,
        //            //    PathToPicture = users[i + 1].PathToPicture,
        //            //    DateOfBirth = users[i + 1].DateOfBirth,
        //            //    UserId = users[i].Id
        //            //});
        //        }
        //        context.SaveChanges();
        //    }
        //}
        private IUserRepository _userRepository;
        private IRecipientRepository _recipientRepository;
    }
}
