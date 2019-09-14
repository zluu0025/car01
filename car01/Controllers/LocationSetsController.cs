using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using car01.Models;

namespace car01.Controllers
{
    [Authorize(Roles ="Admin,Assist")]
    public class LocationSetsController : Controller
    {
        private Model1 db = new Model1();

        // GET: LocationSets
        public ActionResult Index()
        {
            return View(db.LocationSets.ToList());
        }

        // GET: LocationSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationSet locationSet = db.LocationSets.Find(id);
            if (locationSet == null)
            {
                return HttpNotFound();
            }
            return View(locationSet);
        }

        // GET: LocationSets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LocationSets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Locatio_Id,Location_Name,Latitude,Longtitude")] LocationSet locationSet)
        {
            if (ModelState.IsValid)
            {
                db.LocationSets.Add(locationSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(locationSet);
        }

        // GET: LocationSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationSet locationSet = db.LocationSets.Find(id);
            if (locationSet == null)
            {
                return HttpNotFound();
            }
            return View(locationSet);
        }

        // POST: LocationSets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Locatio_Id,Location_Name,Latitude,Longtitude")] LocationSet locationSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locationSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(locationSet);
        }

        // GET: LocationSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationSet locationSet = db.LocationSets.Find(id);
            if (locationSet == null)
            {
                return HttpNotFound();
            }
            return View(locationSet);
        }

        // POST: LocationSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LocationSet locationSet = db.LocationSets.Find(id);
            db.LocationSets.Remove(locationSet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
