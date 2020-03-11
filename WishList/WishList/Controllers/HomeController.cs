using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

using SecretSanta.Data.EF;
using SecretSanta.Data.EF.Repositories.UserRepository;
using SecretSanta.Data.Models;
using SecretSanta.Services.UserServices;
using SecretSanta.Services.GroupService;

namespace WishList.Controllers
{
    public class HomeController : Controller
    {
        private IGroupService _groupService;
        private IUserService _userService;

        public HomeController(IUserService userService, IGroupService groupService)
        {
            _groupService = groupService;
            _userService = userService;
        }
        //[Authorize]
        public ActionResult Index()
        {
            #region Initialize
            //_groupService.CreateGroup(new Group { Name = "ICTIS" });
            //_userService.CreateUser(new User
            //{
            //    FirstName = "Lena",
            //    LastName = "Chernaya",
            //    Email = "1234@mail.ru",
            //    Password = "panda_super_secret_password",
            //    PathToPicture = "path to picture",
            //    IsAdmin = true,
            //    GroupId = 1
            //});
            #endregion
            var user = _userService.GetUser(1);
            var group = _groupService.GetGroup(1);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}