using System;
using System.Web;
using System.Web.Mvc;
using SecretSanta.Data.Models;
using SecretSanta.Services.UserServices;

namespace WishList.Controllers
{
    public class HomeController : Controller
    {
        private IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }
        //[Authorize]
        public ActionResult Index()
        {
            #region Initialize
           //Initialize();
            #endregion
            var user = _userService.GetUser(1);
            var user2 = _userService.GetUser(2);
            var user3 = _userService.GetUser(3);
            //var user = _userService.GetUser(1);
            // UserViewModel 
            ViewBag.User = user;
            //_userService.SetRecipient();
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