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
    public class ProductsController : Controller
    {
        private EncommerceDBContext db = new EncommerceDBContext();

        // GET: Products
        public ActionResult Index(string searchCategory, string searchOrigin, string searchString)
        {
            var GenreLst = new List<string>();

            var GenreQry = from p in db.Products
                           orderby p.Origin
                           select p.Origin;
            GenreLst.AddRange(GenreQry.Distinct());

            var GenreQr = from p1 in db.Products
                          orderby p1.Category.CategoryName
                          select p1.Category.CategoryName;
            GenreLst.AddRange(GenreQr.Distinct());

            ViewBag.searchOrigin = new SelectList(GenreLst);
            ViewBag.searchCategory = new SelectList(GenreLst);
            var product = from p in db.Products
                          select p;
           
            if (!String.IsNullOrEmpty(searchString))
            {
                product = product.Where(s => s.ProductName.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(searchOrigin))
            {
                product = product.Where(x => x.Origin == searchOrigin);
            }
            if (!String.IsNullOrEmpty(searchCategory))
            {
                product = product.Where(s => s.Category.CategoryName == searchCategory);
            }
            return View(product);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.ID_Category = new SelectList(db.Categories, "ID_Category", "CategoryName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Product,ID_Category,ProductName,Image,Origin,Price,Unit,Sale,PriceF,DateManufacture,ExpirationDate,Description,DescriptionDTS,Update")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Category = new SelectList(db.Categories, "ID_Category", "CategoryName", product.ID_Category);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Category = new SelectList(db.Categories, "ID_Category", "CategoryName", product.ID_Category);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Product,ID_Category,ProductName,Image,Origin,Price,Unit,Sale,PriceF,DateManufacture,ExpirationDate,Description,DescriptionDTS,Update")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Category = new SelectList(db.Categories, "ID_Category", "CategoryName", product.ID_Category);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
