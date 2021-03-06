﻿using SecretSanta.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta.Data.EF.Repositories.WishRepository
{
    public class WishRepository : IWishRepository
    {
        public bool ChangeStatus(long id)
        {
            var wish = Get(id);
            wish.IsComlete = !wish.IsComlete;
            Update(wish);
            return wish.IsComlete;
        }

        public void Create(Wish item)
        {
            using (SantaContext context = new SantaContext())
            {
                context.Wishes.Add(item);
                context.SaveChanges();
            }
        }

        public void Delete(Wish item)
        {
            using (SantaContext context = new SantaContext())
            {
                context.Wishes.Attach(item);
                context.Wishes.Remove(item);
                context.SaveChanges();
            }
        }

        public Wish Get(long id)
        {
            using (SantaContext context = new SantaContext())
            {
                return context.Wishes.Include(w => w.User).FirstOrDefault(w => w.Id == id);
            }
        }

        public IEnumerable<Wish> Get()
        {
            using (SantaContext context = new SantaContext())
            {
                return context.Wishes.Include(w => w.User).ToList();
            }
        }

        public IEnumerable<Wish> Get(Func<Wish, bool> predicate)
        {
            using (SantaContext context = new SantaContext())
            {
                return context.Wishes.Where(predicate);
            }
        }

        public void Update(Wish item)
        {
            using (SantaContext context = new SantaContext())
            {
                context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
