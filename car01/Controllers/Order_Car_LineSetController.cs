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
    [Authorize]
    public class Order_Car_LineSetController : Controller
    {
        private Model1 db = new Model1();

        // GET: Order_Car_LineSet
        public ActionResult Index()
        {
            var order_Car_LineSet = db.Order_Car_LineSet.Include(o => o.CarsSet).Include(o => o.OrdersSet);
            return View(order_Car_LineSet.ToList());
        }

        // GET: Order_Car_LineSet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Car_LineSet order_Car_LineSet = db.Order_Car_LineSet.Find(id);
            if (order_Car_LineSet == null)
            {
                return HttpNotFound();
            }
            return View(order_Car_LineSet);
        }

        // GET: Order_Car_LineSet/Create
        public ActionResult Create()
        {
            ViewBag.CarsCar_Id = new SelectList(db.CarsSets, "Car_Id", "Car_Type");
            ViewBag.OrdersOrder_Id = new SelectList(db.OrdersSets, "Order_Id", "UserId");
            return View();
        }

        // POST: Order_Car_LineSet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrdersOrder_Id,CarsCar_Id,Order_dates")] Order_Car_LineSet order_Car_LineSet)
        {
            if (ModelState.IsValid)
            {
                db.Order_Car_LineSet.Add(order_Car_LineSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarsCar_Id = new SelectList(db.CarsSets, "Car_Id", "Car_Type", order_Car_LineSet.CarsCar_Id);
            ViewBag.OrdersOrder_Id = new SelectList(db.OrdersSets, "Order_Id", "UserId", order_Car_LineSet.OrdersOrder_Id);
            return View(order_Car_LineSet);
        }

        // GET: Order_Car_LineSet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Car_LineSet order_Car_LineSet = db.Order_Car_LineSet.Find(id);
            if (order_Car_LineSet == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarsCar_Id = new SelectList(db.CarsSets, "Car_Id", "Car_Type", order_Car_LineSet.CarsCar_Id);
            ViewBag.OrdersOrder_Id = new SelectList(db.OrdersSets, "Order_Id", "UserId", order_Car_LineSet.OrdersOrder_Id);
            return View(order_Car_LineSet);
        }

        // POST: Order_Car_LineSet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrdersOrder_Id,CarsCar_Id,Order_dates")] Order_Car_LineSet order_Car_LineSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order_Car_LineSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarsCar_Id = new SelectList(db.CarsSets, "Car_Id", "Car_Type", order_Car_LineSet.CarsCar_Id);
            ViewBag.OrdersOrder_Id = new SelectList(db.OrdersSets, "Order_Id", "UserId", order_Car_LineSet.OrdersOrder_Id);
            return View(order_Car_LineSet);
        }

        // GET: Order_Car_LineSet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Car_LineSet order_Car_LineSet = db.Order_Car_LineSet.Find(id);
            if (order_Car_LineSet == null)
            {
                return HttpNotFound();
            }
            return View(order_Car_LineSet);
        }

        // POST: Order_Car_LineSet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order_Car_LineSet order_Car_LineSet = db.Order_Car_LineSet.Find(id);
            db.Order_Car_LineSet.Remove(order_Car_LineSet);
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
