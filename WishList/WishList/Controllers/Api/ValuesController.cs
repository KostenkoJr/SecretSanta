using Newtonsoft.Json;
using SecretSanta.Data.Models;
using SecretSanta.Services.FeedbackService;
using SecretSanta.Services.UserServices;
using SecretSanta.Services.WishService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WishList.ViewModel;

namespace WishList.Controllers.Api
{
    public class ValuesController : ApiController
    {
        private IUserService _userService;
        private IWishService _wishService;
        private IFeedbackService _feedbackService;
        public ValuesController(IWishService wishService, IUserService userService, IFeedbackService feedbackService)
        {
            _wishService = wishService;
            _userService = userService;
            _feedbackService = feedbackService;
        }
        [Authorize]
        [HttpGet, Route("api/CheckAndAddToMyWishList/{id}")]
        public IHttpActionResult CheckAndAddToMyWishList(long id)
        {
            string email = User.Identity.Name;
            var user = _userService.GetCurrentUser(email);
            if(user == null)
            {
                return Ok("Go to Login");
            }
            var wish = _wishService.GetWish(id);
            var titleOfMyWishes = user.Wishes.Select(w => w.Title);
            var titleIsExist = titleOfMyWishes.Contains(wish.Title);
            if(titleIsExist)
            {
                var answer = new
                {
                    Status = 200,
                    IsRepeat = true
                };
                return Ok(answer);
            }
            if(wish != null)
            {
                var myWish = new Wish
                {
                    Title = wish.Title,
                    Description = wish.Description,
                    LinkToShop = wish.LinkToShop,
                    PathToPicture = String.IsNullOrEmpty(wish.PathToPicture) ? null : wish.PathToPicture,
                    Price = wish.Price,
                    IsComlete = false,
                    UserId = user.Id
                };
                _wishService.CreateWish(myWish);
            }
            return Ok(true);
        }

        [HttpGet, Route("api/AddToMyWishList/{id}")]
        public IHttpActionResult AddToMyWishList(long id)
        {
            string email = User.Identity.Name;
            var user = _userService.GetCurrentUser(email);
            var wish = _wishService.GetWish(id);
            if (wish != null)
            {
                var myWish = new Wish
                {
                    Title = wish.Title,
                    Description = wish.Description,
                    LinkToShop = wish.LinkToShop,
                    PathToPicture = String.IsNullOrEmpty(wish.PathToPicture) ? null : wish.PathToPicture,
                    Price = wish.Price,
                    IsComlete = false,
                    UserId = user.Id
                };
                _wishService.CreateWish(myWish);
            }
            return Ok(true);
        }

        [HttpPost, Route("api/GetInTouch")]
        public IHttpActionResult GetInTouch([FromBody]FeedbackForm feedback)
        {
            string email = User.Identity.Name;
            var user = _userService.GetCurrentUser(email);
            feedback.UserId = user.Id;
            _feedbackService.GetInTouch(feedback);
            return Ok(true);
        }

        [HttpGet, Route("api/FindUsers")]
        public IHttpActionResult FindUsers([FromUri]string term)
        {
            var users = _userService.GetUsers().Where(u => u.Email.Contains(term)).ToList();
            
            if(users.Count() > 0)
            {
                List<UserSearch> usersSearch = new List<UserSearch>();
                foreach(var user in users)
                {
                    usersSearch.Add(new UserSearch { Id = user.Id, FullName = user.FirstName + " " + user.LastName, Email = user.Email });
                }
                return Ok(JsonConvert.SerializeObject(usersSearch, Formatting.Indented));
            }
            return Ok("No users found");
        }

        struct UserSearch
        {
            public long Id { get; set; }
            public string FullName { get; set; }
            public string Email { get; set; }

        }
    }
}
