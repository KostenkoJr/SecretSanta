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
        // GET: api/Profile
        //[HttpGet, Route("api/ChangeStatus/{id}")]
        //public IHttpActionResult ChangeStatus(long id)
        //{
        //    var isComplete = _wishService.ChangeStatus(id);
           
        //    return Ok(isComplete);
        //}

        [HttpGet, Route("api/CheckAndAddToMyWishList/{id}")]
        public IHttpActionResult CheckAndAddToMyWishList(long id)
        {
            string email = User.Identity.Name;
            var user = _userService.GetCurrentUser(email);
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

        // GET: api/Profile/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost, Route("api/ChangePassword")]
        public void ChangePassword([FromBody]ChangePasswordModel model)
        {
            if(ModelState.IsValid)
            {
                string email = User.Identity.Name;
                var user = _userService.GetCurrentUser(email);
                if(user.Password == model.OldPassword)
                {
                    user.Password = model.NewPassword;
                    _userService.UpdateUser(user);
                }
            }
        }

        [HttpPost, Route("api/ChangeAvatar")]
        public IHttpActionResult ChangeAvatar()
        {
            var httpRequest = HttpContext.Current.Request;
            var postedFile = httpRequest.Files["file"];
            var filePath = HttpContext.Current.Server.MapPath("~/Files/" + postedFile.FileName);
            postedFile.SaveAs(filePath);
            string email = User.Identity.Name;
            var user = _userService.GetCurrentUser(email);
            user.PathToPicture = postedFile.FileName;
            _userService.UpdateUser(user);

            return Ok(postedFile.FileName);
        }

        [HttpPost, Route("api/UploadImage")]
        public IHttpActionResult UploadImage()
        {
            var httpRequest = HttpContext.Current.Request;
            var postedFile = httpRequest.Files["file"];
            var filePath = HttpContext.Current.Server.MapPath("~/Files/" + postedFile.FileName);
            postedFile.SaveAs(filePath);
            return Ok(postedFile.FileName);
        }

        [HttpPost, Route("api/ChangeWish")]
        public IHttpActionResult ChangeWish([FromBody]Wish wish)
        {
            string email = User.Identity.Name;
            var user = _userService.GetCurrentUser(email);
            var _wish = _wishService.GetWish(wish.Id);
            if(_wish.UserId == user.Id)
            {
                _wish.Description = wish.Description;
                _wish.LinkToShop = wish.LinkToShop;
                _wish.PathToPicture = String.IsNullOrEmpty(wish.PathToPicture) ? null : wish.PathToPicture;
                _wish.Price = wish.Price;
                _wish.Title = wish.Title;
                _wishService.UpdateWish(_wish);
                return Ok(true);
            }
            return NotFound();
        }

        [HttpPost, Route("api/CreateWish")]
        public IHttpActionResult CreateWish([FromBody]Wish wish)
        {
            string email = User.Identity.Name;
            var user = _userService.GetCurrentUser(email);
            wish.PathToPicture = String.IsNullOrEmpty(wish.PathToPicture) ? null : wish.PathToPicture;
            wish.UserId = user.Id;
            _wishService.CreateWish(wish);
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

        [HttpPost, Route("api/ChangeProfileDetails")]
        public IHttpActionResult ChangeProfileDetails([FromBody]User user)
        {
            string email = User.Identity.Name;
            var _user = _userService.GetCurrentUser(email);
            if(user != null)
            {
                _user.FirstName = user.FirstName;
                _user.LastName = user.LastName;
                _user.Address = user.Address;
                _user.DateOfBirth = Convert.ToDateTime(user.DateOfBirth);
                _userService.UpdateUser(_user);
            }
            return Ok(true);
        }

        // DELETE: api/Profile/5
        public void Delete(int id)
        {
        }
    }
}
