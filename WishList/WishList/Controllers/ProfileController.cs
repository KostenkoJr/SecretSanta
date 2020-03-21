using SecretSanta.Services.UserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WishList.Controllers
{
    public class ProfileController : Controller
    {
        private IUserService _userService;
        public ProfileController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        public ActionResult Index()
        {
            var email = User.Identity.Name;
            var user = _userService.GetCurrentUser(email);
            if(user != null)
            {
                ViewBag.User = user;
                return View(user);
            }
            return HttpNotFound();
        }
    }
}