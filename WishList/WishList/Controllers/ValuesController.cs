using Newtonsoft.Json;
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

        [HttpPost, Route("api/ChangeImage")]
        public IHttpActionResult ChangeImage()
        {
            var httpRequest = HttpContext.Current.Request;
            var wishId = HttpContext.Current.Request.Params["wishId"];
            var postedFile = httpRequest.Files["file"];
            var filePath = HttpContext.Current.Server.MapPath("~/Files/" + postedFile.FileName);
            postedFile.SaveAs(filePath);
            string email = User.Identity.Name;
            var user = _userService.GetCurrentUser(email);
            var wish = _wishService.GetWish(Convert.ToInt64(wishId));
            if (user.Id == wish.UserId)
            {
                wish.PathToPicture = postedFile.FileName;
                _wishService.UpdateWish(wish);
            }
            //user.PathToPicture = postedFile.FileName;
            //_userService.UpdateUser(user);

            return Ok(postedFile.FileName);
        }

        // DELETE: api/Profile/5
        public void Delete(int id)
        {
        }
    }
}
