using SecretSanta.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta.Data.EF.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        public void Create(User item)
        {
            using (SantaContext context = new SantaContext())
            {
                context.Users.Add(item);
                context.SaveChanges();
            }
        }

        public void Delete(User item)
        {
            using (SantaContext context = new SantaContext())
            {
                context.Users.Remove(item);
                context.SaveChanges();
            }
        }

        public User Get(long id)
        {
            using (SantaContext context = new SantaContext())
            {
                return context.Users.Include(u => u.Group).FirstOrDefault(u => u.Id == id);
            }
        }

        public IEnumerable<User> Get()
        {
            using (SantaContext context = new SantaContext())
            {
                return context.Users.ToList();
            }
        }
        public void Update(User user)
        {
            using (SantaContext context = new SantaContext())
            {
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
