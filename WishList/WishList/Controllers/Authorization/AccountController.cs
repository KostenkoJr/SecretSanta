using SecretSanta.Data.Models;
using SecretSanta.Services.AuthorizeService;
using SecretSanta.Services.FileService;
using SecretSanta.Services.UserServices;
using System;
using System.Web.Mvc;
using System.Web.Security;
using WishList.Controllers.Authorization.Model;
using WishList.ViewModel;

namespace WishList.Controllers.Authorization
{
    public class AccountController : Controller
    {
        public AccountController(IAuthorizeService authorizeService, IUserService userService)
        {
            _authorizeService = authorizeService;
            _userService = userService;

        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AuthorizeViewModel authModel)
        {
            if (ModelState.IsValid)
            {
                LoginModel model = authModel.Login;
                // поиск пользователя в бд
                User loginUser = _authorizeService.Login(model.Email, model.Password);
                if (loginUser != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
            }

            return View(authModel);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(AuthorizeViewModel authModel)
        {
            if (ModelState.IsValid)
            {
                RegisterModel model = authModel.Register;
                Boolean isUsserExist = _authorizeService.IsUserExist(model.Email);
                if (!isUsserExist)
                {
                    // cre
                    _userService.CreateUser(new User
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        Password = model.Password,
                        DateOfBirth = DateTime.Now
                        //PathToPicture = pathToFile
                    });
                    User user = _userService.GetCurrentUser(model.Email);
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Email, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "This email address already exists");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
        private IAuthorizeService _authorizeService;
        private IUserService _userService;
    }
}