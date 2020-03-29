using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SecretSanta.Data.Models;
using SecretSanta.Services.UserServices;
using SecretSanta.Services.WishService;

namespace WishList.Controllers
{
    public class HomeController : Controller
    {
        private IUserService _userService;
        private IWishService _wishService;

        public HomeController(IUserService userService, IWishService wishService)
        {
            _wishService = wishService;
            _userService = userService;
        }
        //[Authorize]
        public ActionResult Index()
        {
            #region Initialize
            //Initialize();
            #endregion
            var email = User.Identity.Name;
            var user = _userService.GetCurrentUser(email);
            var wishes = _wishService.GetWishes().Where(w => w.UserId != user.Id).OrderByDescending(w => w.Date);

            ViewBag.Wishes = wishes;
            return View();
        }
        public ActionResult MyWishes()
        {
            var email = User.Identity.Name;
            var user = _userService.GetCurrentUser(email);
            var wishes = _wishService.GetWishes().Where(w => w.UserId == user.Id).OrderByDescending(w => w.Date);
            ViewBag.Wishes = wishes;
            return View();
        }

        public ActionResult RecipientWishes()
        {
            var email = User.Identity.Name;
            var user = _userService.GetCurrentUser(email);
            var recipient = user.Recipient;
            if(recipient == null)
            {
                return RedirectToAction("UserIsntFound", "Profile");
                
            }
            var wishes = _wishService.GetWishes().Where(w => w.UserId == user.Recipient.Id).OrderByDescending(w => w.Date);
            ViewBag.Wishes = wishes;
            ViewBag.Recipient = recipient;
            return View();
        }

        public void Initialize()
        {
            _userService.CreateUser(new User
            {
                FirstName = "Lena",
                LastName = "Chernaya",
                Email = "9@mail.ru",
                Password = "1234",
                PathToPicture = "path to picture",
                IsAdmin = true,
                Address = "New address",
                DateOfBirth = DateTime.Now
            });
            _userService.CreateUser(new User
            {
                FirstName = "Lena",
                LastName = "Chernaya",
                Email = "99@mail.ru",
                Password = "panda_super_secret_password",
                PathToPicture = "path to picture",
                IsAdmin = false,
                Address = "Peski, Vologodskay oblast1",
                DateOfBirth = DateTime.Now
            });
            _userService.CreateUser(new User
            {
                FirstName = "Lena",
                LastName = "Chernaya",
                Email = "88@mail.ru",
                Password = "panda_super_secret_password",
                PathToPicture = "path to picture",
                IsAdmin = false,
                Address = "Peski, Vologodskay oblast2",
                DateOfBirth = DateTime.Now
            });
        }
        //public Action 
    }
}