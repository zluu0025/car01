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
    [Authorize(Roles ="Admin, Assist")]
    public class CarsSetsController : Controller
    {
        private Model1 db = new Model1();

        // GET: CarsSets
        public ActionResult Index()
        {
            var carsSets = db.CarsSets.Include(c => c.LocationSet);
            return View(carsSets.ToList());
        }

        // GET: CarsSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarsSet carsSet = db.CarsSets.Find(id);
            if (carsSet == null)
            {
                return HttpNotFound();
            }
            return View(carsSet);
        }

        // GET: CarsSets/Create
        public ActionResult Create()
        {
            ViewBag.LocationLocatio_Id1 = new SelectList(db.LocationSets, "Locatio_Id", "Location_Name");
            return View();
        }

        // POST: CarsSets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Car_Id,Car_Type,Car_MarK,Car_Vin,Car_Price,Car_License_Plate,LocationLocatio_Id1")] CarsSet carsSet)
        {
            if (ModelState.IsValid)
            {
                db.CarsSets.Add(carsSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LocationLocatio_Id1 = new SelectList(db.LocationSets, "Locatio_Id", "Location_Name", carsSet.LocationLocatio_Id1);
            return View(carsSet);
        }

        // GET: CarsSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarsSet carsSet = db.CarsSets.Find(id);
            if (carsSet == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocationLocatio_Id1 = new SelectList(db.LocationSets, "Locatio_Id", "Location_Name", carsSet.LocationLocatio_Id1);
            return View(carsSet);
        }

        // POST: CarsSets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Car_Id,Car_Type,Car_MarK,Car_Vin,Car_Price,Car_License_Plate,LocationLocatio_Id1")] CarsSet carsSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carsSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocationLocatio_Id1 = new SelectList(db.LocationSets, "Locatio_Id", "Location_Name", carsSet.LocationLocatio_Id1);
            return View(carsSet);
        }

        // GET: CarsSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarsSet carsSet = db.CarsSets.Find(id);
            if (carsSet == null)
            {
                return HttpNotFound();
            }
            return View(carsSet);
        }

        // POST: CarsSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarsSet carsSet = db.CarsSets.Find(id);
            db.CarsSets.Remove(carsSet);
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
