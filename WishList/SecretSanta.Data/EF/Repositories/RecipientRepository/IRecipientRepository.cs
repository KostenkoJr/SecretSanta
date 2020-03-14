using SecretSanta.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta.Data.EF.Repositories.RecipientRepository
{
    public interface IRecipientRepository
    {
        void CreateRecipient(Recipient recipient);
        void SetRecipientForUsers(List<User> users);
    }
}
