using SecretSanta.Data.Models;
using SecretSanta.Services.FeedbackService;
using SecretSanta.Services.UserServices;
using SecretSanta.Services.WishService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace WishList.Controllers.Api
{
    public class WishController : ApiController
    {
        
        public WishController(IWishService wishService, IUserService userService, IFeedbackService feedbackService)
        {
            _wishService = wishService;
            _userService = userService;
            _feedbackService = feedbackService;
        }
        #region Get
        [HttpGet, Route("api/DeleteWish/{id}")]
        public IHttpActionResult DeleteWish(long? id)
        {
            string email = User.Identity.Name;
            var user = _userService.GetCurrentUser(email);
            var wish = _wishService.GetWish(id.Value);
            if(wish != null && wish.UserId == user.Id)
            {
                _wishService.DeleteWish(wish);
            }
            return Ok(true);
        }

        [HttpGet, Route("api/ChangeStatus/{id}")]
        public IHttpActionResult ChangeStatus(long id)
        {
            var isComplete = _wishService.ChangeStatus(id);

            return Ok(isComplete);
        }
        #endregion

        #region Post
        [HttpPost, Route("api/ChangeWish")]
        public IHttpActionResult ChangeWish([FromBody]Wish wish)
        {
            string email = User.Identity.Name;
            var user = _userService.GetCurrentUser(email);
            var _wish = _wishService.GetWish(wish.Id);
            if (_wish.UserId == user.Id)
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

        [HttpPost, Route("api/UploadImage")]
        public IHttpActionResult UploadImage()
        {
            var httpRequest = HttpContext.Current.Request;
            var postedFile = httpRequest.Files["file"];
            var filePath = HttpContext.Current.Server.MapPath("~/Files/" + postedFile.FileName);
            postedFile.SaveAs(filePath);
            return Ok(postedFile.FileName);
        }
        #endregion

        #region Private
        private IUserService _userService;
        private IWishService _wishService;
        private IFeedbackService _feedbackService;
        #endregion
    }
}
