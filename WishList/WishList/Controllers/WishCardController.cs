using SecretSanta.Data.EF.Repositories.WishRepository;
using SecretSanta.Data.Models;
using SecretSanta.Services.WishService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WishList.Controllers
{
    public class WishCardController : Controller
    {
        private IWishService _wishService;
        public WishCardController(IWishService wishService)
        {
            _wishService = wishService;
        }
        public ActionResult Details(Int64? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }
            var wish = _wishService.GetWish(id.Value);
            return PartialView(wish);
        }

        // GET: WishCard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WishCard/Create
        [HttpPost]
        public ActionResult Create(Wish wish)
        {
            try
            {
                if (wish != null)
                {
                    _wishService.CreateWish(wish);
                }
                // TODO: Add insert logic here
                return RedirectToAction("Details");
            }
            catch
            {
                return View();
            }
        }

        // GET: WishCard/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WishCard/Edit/5
        [HttpPost]
        public ActionResult Edit(Wish wish)
        {
            try
            {
                //var _wish = _wishService.GetWish(wish.Id);
                //_wish.Title = wish.Title;
                //_wish.Price = wish.Price;
                //_wish.PathToPicture = wish.PathToPicture;
                //_wish.IsComlete = wish.IsComlete;
                //_wish.LinkToShop = wish.LinkToShop;
                //_wish.Description = wish.Description;
                _wishService.UpdateWish(wish);
                
                // TODO: Add update logic here

                return Json(new { Id = 1, Name = "123" });
            }
            catch
            {
                
                return View();
            }
        }

        // GET: WishCard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WishCard/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
