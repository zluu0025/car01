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
    [Authorize(Roles = "Admin, Assist")]
    public class Return_RecordsSetController : Controller
    {
        private Model1 db = new Model1();

        // GET: Return_RecordsSet
        public ActionResult Index()
        {
            var return_RecordsSet = db.Return_RecordsSet.Include(r => r.LocationSet).Include(r => r.OrdersSet);
            return View(return_RecordsSet.ToList());
        }

        // GET: Return_RecordsSet/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Return_RecordsSet return_RecordsSet = db.Return_RecordsSet.Find(id);
            if (return_RecordsSet == null)
            {
                return HttpNotFound();
            }
            return View(return_RecordsSet);
        }

        // GET: Return_RecordsSet/Create
        public ActionResult Create()
        {
            ViewBag.Return_Location_Id = new SelectList(db.LocationSets, "Locatio_Id", "Location_Name");
            ViewBag.OrdersOrder_Id = new SelectList(db.OrdersSets, "Order_Id", "UserId");
            return View();
        }

        // POST: Return_RecordsSet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Actual_Return_Date,OrdersOrder_Id,Return_Location_Id")] Return_RecordsSet return_RecordsSet)
        {
            if (ModelState.IsValid)
            {
                db.Return_RecordsSet.Add(return_RecordsSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Return_Location_Id = new SelectList(db.LocationSets, "Locatio_Id", "Location_Name", return_RecordsSet.Return_Location_Id);
            ViewBag.OrdersOrder_Id = new SelectList(db.OrdersSets, "Order_Id", "UserId", return_RecordsSet.OrdersOrder_Id);
            return View(return_RecordsSet);
        }

        // GET: Return_RecordsSet/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Return_RecordsSet return_RecordsSet = db.Return_RecordsSet.Find(id);
            if (return_RecordsSet == null)
            {
                return HttpNotFound();
            }
            ViewBag.Return_Location_Id = new SelectList(db.LocationSets, "Locatio_Id", "Location_Name", return_RecordsSet.Return_Location_Id);
            ViewBag.OrdersOrder_Id = new SelectList(db.OrdersSets, "Order_Id", "UserId", return_RecordsSet.OrdersOrder_Id);
            return View(return_RecordsSet);
        }

        // POST: Return_RecordsSet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Actual_Return_Date,OrdersOrder_Id,Return_Location_Id")] Return_RecordsSet return_RecordsSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(return_RecordsSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Return_Location_Id = new SelectList(db.LocationSets, "Locatio_Id", "Location_Name", return_RecordsSet.Return_Location_Id);
            ViewBag.OrdersOrder_Id = new SelectList(db.OrdersSets, "Order_Id", "UserId", return_RecordsSet.OrdersOrder_Id);
            return View(return_RecordsSet);
        }

        // GET: Return_RecordsSet/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Return_RecordsSet return_RecordsSet = db.Return_RecordsSet.Find(id);
            if (return_RecordsSet == null)
            {
                return HttpNotFound();
            }
            return View(return_RecordsSet);
        }

        // POST: Return_RecordsSet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Return_RecordsSet return_RecordsSet = db.Return_RecordsSet.Find(id);
            db.Return_RecordsSet.Remove(return_RecordsSet);
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
