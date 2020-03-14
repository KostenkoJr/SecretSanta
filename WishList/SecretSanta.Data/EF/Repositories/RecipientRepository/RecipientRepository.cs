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
        public void SetRecipientForUsers(List<User> users)
        {
            using (SantaContext context = new SantaContext())
            {
                CreateRecipient(new Recipient
                {
                    Id = users[users.Count() - 1].Id,
                    FirstName = users[0].FirstName,
                    LastName = users[0].LastName,
                    Email = users[0].Email,
                    PathToPicture = users[0].PathToPicture
                });

                for (int i = 0; i < users.Count() - 1; i++)
                {
                    CreateRecipient(new Recipient
                    {
                        Id = users[i].Id,
                        FirstName = users[i + 1].FirstName,
                        LastName = users[i + 1].LastName,
                        Email = users[i + 1].Email,
                        PathToPicture = users[i + 1].PathToPicture
                    });
                }
                context.SaveChanges();
            }
        }
    }
}
