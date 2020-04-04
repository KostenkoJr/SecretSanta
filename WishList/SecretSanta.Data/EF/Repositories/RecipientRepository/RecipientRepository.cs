using SecretSanta.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta.Data.EF.Repositories.RecipientRepository
{
    public class RecipientRepository : IRecipientRepository
    {
        public void CreateRecipient(Recipient recipient)
        {
            using (SantaContext context = new SantaContext())
            {
                context.Recipients.Add(recipient);
                context.SaveChanges();
            }
        }
        //TODO Вынести в сервис
        public void SetRecipientForUsers(List<User> users)
        {
            using (SantaContext context = new SantaContext())
            {
                users[users.Count() - 1].RecipientId = users[0].Id;

                for (int i = 0; i < users.Count() - 1; i++)
                {
                    context.Users.Attach(users[i]);
                    users[i].RecipientId = users[i + 1].Id;
                    users[i].Recipient = users[i + 1];
                    //CreateRecipient(new Recipient
                    //{
                    //    Id = users[i + 1].Id,
                    //    FirstName = users[i + 1].FirstName,
                    //    LastName = users[i + 1].LastName,
                    //    Email = users[i + 1].Email,
                    //    PathToPicture = users[i + 1].PathToPicture,
                    //    DateOfBirth = users[i + 1].DateOfBirth,
                    //    UserId = users[i].Id
                    //});
                }
                context.SaveChanges();
            }
        }
    }
}
