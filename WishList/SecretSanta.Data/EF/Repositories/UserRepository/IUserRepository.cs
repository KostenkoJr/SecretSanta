using SecretSanta.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta.Data.EF.Repositories.UserRepository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User Login(String email, String password);
        User GetCurrentUser(String email);
        Boolean IsUserExist(String email);
        //void SetRecipient(Recipient recipient);
    }
}
