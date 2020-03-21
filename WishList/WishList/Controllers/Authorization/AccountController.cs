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
            if(User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Profile");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AuthorizeViewModel authModel)
        {
            if (ModelState.IsValid)
            {
                LoginModel model = authModel.Login;
                // Search user by email
                User loginUser = _authorizeService.Login(model.Email, model.Password);
                if (loginUser != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return RedirectToAction("Index", "Profile");
                }
                else
                {
                    ModelState.AddModelError("", "The username or password is incorrect");
                }
            }

            return View(authModel);
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
                    // Create the user
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
            return View("Login", authModel);
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