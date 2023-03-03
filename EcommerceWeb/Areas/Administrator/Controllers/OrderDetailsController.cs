using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Encommerce_Model;

namespace EcommerceWeb.Areas.Administrator.Controllers
{
    public class OrderDetailsController : Controller
    {
        private EncommerceDBContext db = new EncommerceDBContext();

        // GET: Administrator/OrderDetails
        public ActionResult Index(string searchPaym, string searchString)
        {
            var GenreLst = new List<string>();

            var GenreQry = from p in db.OrderDetails
                           orderby p.Status_
                           select p.Status_;
            GenreLst.AddRange(GenreQry.Distinct());
            ViewBag.searchPaym = new SelectList(GenreLst);

            var orderdetail = from m in db.OrderDetails
                             select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                orderdetail = orderdetail.Where(s => s.OrderDetailsName.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(searchPaym))
            {
                orderdetail = orderdetail.Where(s => s.Status_==searchPaym);
            }
           
            return View(orderdetail);
        }
        [HttpPost]
        public string Index(FormCollection fc, string searchString)
        {
            return "<h3> From [HttpPost]Index: " + searchString + "</h3>";
        }
        // GET: Administrator/OrderDetails/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetails orderDetail = db.OrderDetails.Find(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderDetail);
        }

        // GET: Administrator/OrderDetails/Create
        public ActionResult Create()
        {
            ViewBag.ID_Order = new SelectList(db.Orders, "ID_Order", "ProductName");
            ViewBag.ID_User = new SelectList(db.Users, "ID_User", "UserName");
            return View();
        }

        // POST: Administrator/OrderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_OrderDetails,OrderDetailsName,ID_User,ID_Order,TotalPrice,Status_,ODate")] OrderDetails orderDetail)
        {
            if (ModelState.IsValid)
            {
                db.OrderDetails.Add(orderDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Order = new SelectList(db.Orders, "ID_Order", "ProductName", orderDetail.ID_Order);
            ViewBag.ID_User = new SelectList(db.Users, "ID_User", "UserName", orderDetail.ID_User);
            return View(orderDetail);
        }

        // GET: Administrator/OrderDetails/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetails orderDetail = db.OrderDetails.Find(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Order = new SelectList(db.Orders, "ID_Order", "ProductName", orderDetail.ID_Order);
            ViewBag.ID_User = new SelectList(db.Users, "ID_User", "UserName", orderDetail.ID_User);
            return View(orderDetail);
        }

        // POST: Administrator/OrderDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_OrderDetails,OrderDetailsName,ID_User,ID_Order,TotalPrice,Status_,ODate")] OrderDetails orderDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Order = new SelectList(db.Orders, "ID_Order", "ProductName", orderDetail.ID_Order);
            ViewBag.ID_User = new SelectList(db.Users, "ID_User", "UserName", orderDetail.ID_User);
            return View(orderDetail);
        }

        // GET: Administrator/OrderDetails/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetails orderDetail = db.OrderDetails.Find(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderDetail);
        }

        // POST: Administrator/OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderDetails orderDetail = db.OrderDetails.Find(id);
            db.OrderDetails.Remove(orderDetail);
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
