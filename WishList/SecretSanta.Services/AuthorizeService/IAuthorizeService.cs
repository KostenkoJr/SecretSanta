using SecretSanta.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta.Services.AuthorizeService
{
    public interface IAuthorizeService
    {
        User Login(String email, String password);
        Boolean IsUserExist(String email);
        void RegisterUser(User user);
        bool ChangePassword(User user, String oldPassword, String newPassword);
    }
}
