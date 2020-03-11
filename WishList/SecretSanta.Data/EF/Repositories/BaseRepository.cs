using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta.Data.EF.Repositories
{
    //public abstract class BaseRepository : IBaseRepository<TEntity> where TEntity : class
    //{
    //    DbSet<T> DbSet;
    //    SantaContext Context;
    //    public BaseRepository(SantaContext context)
    //    {
    //        Context = context;
    //        DbSet = context.Set<T>();
    //    }
    //    public T Get(Int64 id)
    //    {
    //        return DbSet.Find(id);
    //    }
    //    public IEnumerable<T> Get()
    //    {
    //        return DbSet.ToList();
    //    }
    //    public Int64 Create(T item)
    //    {
    //        DbSet.Add(item);
    //        return Context.SaveChanges();
    //    }

    //    public T Get<T>(long id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IEnumerable<T> Get<T>()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Delete<T>(T item)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Create<T>(T item)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
