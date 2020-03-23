using SecretSanta.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta.Data.EF.Repositories.WishRepository
{
    public interface IWishRepository : IBaseRepository<Wish>
    {
        bool ChangeStatus(long id);
    }
}
