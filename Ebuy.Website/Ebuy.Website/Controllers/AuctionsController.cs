using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ebuy.Website.Models;

namespace Ebuy.Website.Controllers
{
    public class AuctionsController : Controller
    {
        //
        // GET: /Auctions/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Auctions/Details/5

        public ActionResult Details(long id = 0)
        {
            var db = new EbuyDataContext();
            var auction = db.Auctions.FirstOrDefault(x => x.Id == id);
            if (auction == null)
            {
                return HttpNotFound();
            }
            return View(auction);
        }

        //
        // GET: /Auctions/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Auctions/Create

        [HttpPost]
        public ActionResult Create(Auction auction)
        {
            if (auction.EndTime <= DateTime.Now.AddDays(1))
            {
                ModelState.AddModelError(
                "EndTime",
                "Auction must be at least one day long"
                );
            }
            if (ModelState.IsValid)
            {
                var db = new EbuyDataContext();
                db.Auctions.Add(auction);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = auction.Id });
            }

            return View(auction);
        }

        //
        // GET: /Auctions/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Auctions/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Auctions/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Auctions/Delete/5

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
