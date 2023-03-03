using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Encommerce_Model;

namespace EcommerceWeb.Controllers
{
    public class OrdersController : Controller
    {
        private EncommerceDBContext db = new EncommerceDBContext();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Product).Include(o => o.User);
            return View(orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.ID_Product = new SelectList(db.Products, "ID_Product", "ProductName");
            ViewBag.ID_User = new SelectList(db.Users, "ID_User", "UserName");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Order,ID_User,ID_Product,ProductName,Unit,Image,PaymentMethod,Price,Amount,TotalPrice,OrderDate,Note")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Product = new SelectList(db.Products, "ID_Product", "ProductName", order.ID_Product);
            ViewBag.ID_User = new SelectList(db.Users, "ID_User", "UserName", order.ID_User);
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Product = new SelectList(db.Products, "ID_Product", "ProductName", order.ID_Product);
            ViewBag.ID_User = new SelectList(db.Users, "ID_User", "UserName", order.ID_User);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Order,ID_User,ID_Product,ProductName,Unit,Image,PaymentMethod,Price,Amount,TotalPrice,OrderDate,Note")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Product = new SelectList(db.Products, "ID_Product", "ProductName", order.ID_Product);
            ViewBag.ID_User = new SelectList(db.Users, "ID_User", "UserName", order.ID_User);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
        public Cart GetOrder()
        {
            Cart order = Session["Cart"] as Cart;
            if(order ==null || Session["Cart"] == null)
            {
                order = new Cart();
                Session["Cart"] = order;
            }
            return order;
        }
        public ActionResult AddtoCart(int id)
        {
            var product = db.Products.SingleOrDefault(s => s.ID_Product == id);
            if (product == null)
            {
                GetOrder().Add(product);
            }
            return RedirectToAction("ShowToCart", "Order");
        }
        public ActionResult ShowToCart()
        {
            if (Session["Cart"] == null)
                return RedirectToAction("ShowToCart", "Order");
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }
    }
}
