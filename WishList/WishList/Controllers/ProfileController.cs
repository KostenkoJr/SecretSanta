﻿using SecretSanta.Data.Models;
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
                IList<Wish> wishes = user.Wishes;
                wishes = wishes.OrderByDescending(w => w.Date).ToList();
                ViewBag.Wishes = wishes;
                return View(user);
            }
            return HttpNotFound();
        }

        [Authorize]
        public ActionResult AnotherUser(long? id)
        {
            if(id != null)
            {
                var user = _userService.GetUser(id.Value);
                if (user != null)
                {
                    return View(user);
                }
            }
            return HttpNotFound();
        }

        public ActionResult UserIsntFound()
        {
            return View();
        }
    }
}