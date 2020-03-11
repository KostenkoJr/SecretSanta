using SecretSanta.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta.Data.EF.Repositories.GroupRepository
{
    public class GroupRepository : IGroupRepository
    {
        public void Create(Group item)
        {
            using (SantaContext context = new SantaContext())
            {
                context.Groups.Add(item);
                context.SaveChanges();
            }
        }

        public void Delete(Group item)
        {
            using (SantaContext context = new SantaContext())
            {
                context.Groups.Remove(item);
                context.SaveChanges();
            }
        }

        public Group Get(long id)
        {
            using (SantaContext context = new SantaContext())
            {
               return context.Groups.Include(g => g.Users).FirstOrDefault(g => g.Id == id);
            }
        }

        public IEnumerable<Group> Get()
        {
            using (SantaContext context = new SantaContext())
            {
                return context.Groups.Include(g => g.Users);
            }
        }

        public void Update(Group item)
        {
            using (SantaContext context = new SantaContext())
            {
                context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
