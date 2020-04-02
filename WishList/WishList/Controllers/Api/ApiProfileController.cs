using SecretSanta.Data.Models;
using SecretSanta.Services.FeedbackService;
using SecretSanta.Services.UserServices;
using SecretSanta.Services.WishService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WishList.Controllers.Api
{
    public class ApiProfileController : ApiController
    {
        private IUserService _userService;
        private IWishService _wishService;
        private IFeedbackService _feedbackService;
        public ApiProfileController(IWishService wishService, IUserService userService, IFeedbackService feedbackService)
        {
            _wishService = wishService;
            _userService = userService;
            _feedbackService = feedbackService;
        }

        [HttpGet, Route("api/ChangeStatus/{id}")]
        public IHttpActionResult ChangeStatus(long id)
        {
            var isComplete = _wishService.ChangeStatus(id);

            return Ok(isComplete);
        }
    }
}
