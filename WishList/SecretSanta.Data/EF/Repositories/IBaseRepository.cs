using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta.Data.EF.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        T Get(Int64 id);
        IEnumerable<T> Get();
        IEnumerable<T> Get(Func<T, bool> predicate);
        void Delete(T item);
        void Create(T item);
        void Update(T item);
    }
}
