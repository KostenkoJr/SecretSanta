using SecretSanta.Data.Models;
using SecretSanta.Services.AuthorizeService;
using SecretSanta.Services.UserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WishList.Controllers.Authorization.Model;


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
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
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

            return View(model);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                Boolean isUsserExist = _authorizeService.IsUserExist(model.Email);
                if (!isUsserExist)
                {
                    // создаем нового пользователя
                    _userService.CreateUser(new User
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        Password = model.Password
                    });
                    // если пользователь удачно добавлен в бд
                    User user = _userService.GetCurrentUser(model.Email);
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Email, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }
            return View(model);
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