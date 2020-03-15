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
                return context.Users.Include(u => u.Recipient).FirstOrDefault(u => u.Id == id);
            }
        }
        public User Login(String email, String password)
        {
            using (SantaContext context = new SantaContext())
            {
                return context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            }
        }

        public IEnumerable<User> Get()
        {
            using (SantaContext context = new SantaContext())
            {
                return context.Users.Include(u => u.Recipient).ToList();
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

        public bool IsUserExist(string email)
        {
            using (SantaContext context = new SantaContext())
            {
                return context.Users.FirstOrDefault(u => u.Email == email) != null;
            }
        }

        public User GetCurrentUser(string email)
        {
            using (SantaContext context = new SantaContext())
            {
                return context.Users.FirstOrDefault(u => u.Email == email);
            }
        }

        public IEnumerable<User> Get(Func<User, bool> predicate)
        {
            using (SantaContext context = new SantaContext())
            {
                return context.Users.Where(predicate).ToList();
            }
        }

        
    }
}
