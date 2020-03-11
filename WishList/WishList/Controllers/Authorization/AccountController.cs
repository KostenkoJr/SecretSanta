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
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            //if (ModelState.IsValid)
            //{
            //    // поиск пользователя в бд
            //    UserModel user = null;
            //    using (DbContextApp context = new DbContextApp())
            //    {
            //        user = context.Users.FirstOrDefault(u => u.Email == model.Name && u.Password == model.Password);
            //    }
            //    if (user != null)
            //    {
            //        FormsAuthentication.SetAuthCookie(model.Name, true);
            //        return RedirectToAction("Index", "Home");
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
            //    }
            //}

            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            //if (ModelState.IsValid)
            //{
            //    UserModel user = null;
            //    using (DbContextApp context = new DbContextApp())
            //    {
            //        user = context.Users.FirstOrDefault(u => u.Email == model.Email);
            //    }
            //    if (user == null)
            //    {
            //        // создаем нового пользователя
            //        using (DbContextApp context = new DbContextApp())
            //        {
            //            context.Users.Add(new UserModel { 
            //                FirstName = model.FirstName, 
            //                LastName = model.LastName, 
            //                NickName = model.NickName,
            //                Email = model.Email,
            //                Password = model.Password  
            //            });
            //            context.SaveChanges();

            //            user = context.Users.Where(u => u.Email == model.Email && u.Password == model.Password).FirstOrDefault();
            //        }
            //        // если пользователь удачно добавлен в бд
            //        if (user != null)
            //        {
            //            FormsAuthentication.SetAuthCookie(model.Email, true);
            //            return RedirectToAction("Index", "Home");
            //        }
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("", "Пользователь с таким логином уже существует");
            //    }
            //}

            return View(model);
        }
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}