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
            var users = _userService.GetUsers();
            var wishes = _wishService.GetWishes()/*.OrderByDescending(w => w.Date)*/;

            ViewBag.Wishes = wishes;
            return View();
        }
        public void Initialize()
        {
            _userService.CreateUser(new User
            {
                FirstName = "Lena",
                LastName = "Chernaya",
                Email = "9@mail.ru",
                Password = "panda_super_secret_password",
                PathToPicture = "path to picture",
                IsAdmin = false,
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
                DateOfBirth = DateTime.Now
            });
            _userService.CreateUser(new User
            {
                FirstName = "Lena",
                LastName = "Chernaya",
                Email = "77@mail.ru",
                Password = "panda_super_secret_password",
                PathToPicture = "path to picture",
                IsAdmin = false,
                DateOfBirth = DateTime.Now
            });
            _userService.CreateUser(new User
            {
                FirstName = "Lena",
                LastName = "Chernaya",
                Email = "66@mail.ru",
                Password = "panda_super_secret_password",
                PathToPicture = "path to picture",
                IsAdmin = false,
                DateOfBirth = DateTime.Now
            });
            _userService.CreateUser(new User
            {
                FirstName = "Lena",
                LastName = "Chernaya",
                Email = "55@mail.ru",
                Password = "panda_super_secret_password",
                PathToPicture = "path to picture",
                IsAdmin = false,
                DateOfBirth = DateTime.Now
            });
        }
        //public Action 
    }
}