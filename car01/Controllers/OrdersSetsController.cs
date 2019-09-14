using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using car01.Models;
using Microsoft.AspNet.Identity;

namespace car01.Controllers
{
    [Authorize]
    public class OrdersSetsController : Controller
    {
        private Model1 db = new Model1();

        // GET: OrdersSets
        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var ordersSet = db.OrdersSets.Where(o => o.UserId == userId).ToList();

            return View(ordersSet);
        }

        // GET: OrdersSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdersSet ordersSet = db.OrdersSets.Find(id);
            if (ordersSet == null)
            {
                return HttpNotFound();
            }
            return View(ordersSet);
        }

        // GET: OrdersSets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrdersSets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Order_Id,Renting_Start_Date,Renting_End_Date,Total_Renting_Fee")] OrdersSet ordersSet)
        {
            ordersSet.UserId = User.Identity.GetUserId();

            ModelState.Clear();
            TryValidateModel(ordersSet);

            if (ModelState.IsValid)
            {
                db.OrdersSets.Add(ordersSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ordersSet);
        }

        // GET: OrdersSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdersSet ordersSet = db.OrdersSets.Find(id);
            if (ordersSet == null)
            {
                return HttpNotFound();
            }
            return View(ordersSet);
        }

        // POST: OrdersSets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Order_Id,UserId,Renting_Start_Date,Renting_End_Date,Total_Renting_Fee")] OrdersSet ordersSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordersSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ordersSet);
        }

        // GET: OrdersSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdersSet ordersSet = db.OrdersSets.Find(id);
            if (ordersSet == null)
            {
                return HttpNotFound();
            }
            return View(ordersSet);
        }

        // POST: OrdersSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrdersSet ordersSet = db.OrdersSets.Find(id);
            db.OrdersSets.Remove(ordersSet);
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
