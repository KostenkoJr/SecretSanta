using SecretSanta.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta.Services.WishService
{
    public interface IWishService
    {
        Wish GetWish(Int64 id);
        IEnumerable<Wish> GetWishes();
        void CreateWish(Wish wish);
        void DeleteWish(Wish wish);
        void UpdateWish(Wish wish);
    }
}
