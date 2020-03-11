using SecretSanta.Data.EF.Repositories.WishRepository;
using SecretSanta.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta.Services.WishService
{
    public class WishService : IWishService
    {
        public WishService(IWishRepository wishRepository)
        {
            _wishRepository = wishRepository;
        }
        public void CreateWish(Wish wish)
        {
            _wishRepository.Create(wish);
        }

        public void DeleteWish(Wish wish)
        {
            _wishRepository.Delete(wish);
        }

        public Wish GetWish(long id)
        {
            return _wishRepository.Get(id);
        }

        public IEnumerable<Wish> GetWishes()
        {
            return _wishRepository.Get();
        }

        public void UpdateWish(Wish wish)
        {
            _wishRepository.Update(wish);
        }
        private IWishRepository _wishRepository;
    }
}
