using SecretSanta.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta.Services.UserServices
{
    public interface IUserService
    {
        User GetUser(Int64 id);
        User GetCurrentUser(String email);
        IEnumerable<User> GetUsers();
        void CreateUser(User user);
        void DeleteUser(User user);
        void UpdateUser(User user);
    }
}
