using SecretSanta.Data.EF.Repositories.WishRepository;
using SecretSanta.Data.Models;
using System.Collections.Generic;

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

        public bool ChangeStatus(long id)
        {
            return _wishRepository.ChangeStatus(id);
        }
        private IWishRepository _wishRepository;
    }
}
