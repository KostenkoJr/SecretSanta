using Newtonsoft.Json;
using SecretSanta.Data.Models;
using SecretSanta.Services.UserServices;
using SecretSanta.Services.WishService;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using WishList.ViewModel;

namespace WishList.Controllers.Api
{
    public class ValuesController : ApiController
    {
        private IUserService _userService;

        private IWishService _wishService;
        public ValuesController(IWishService wishService, IUserService userService)
        {
            _wishService = wishService;
            _userService = userService;
        }
        // GET: api/Profile
        [HttpGet, Route("api/ChangeStatus/{id}")]
        public IHttpActionResult Get(long id)
        {
            var isComplete = _wishService.ChangeStatus(id);
           
            return Ok(isComplete);
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

        // DELETE: api/Profile/5
        public void Delete(int id)
        {
        }
    }
}
