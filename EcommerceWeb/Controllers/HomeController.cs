using Encommerce_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/*
//Chỉnh sửa bảng giá hiện thị (sale), thông tin sản phẩm trong EcommerceWeb/Views/Home/Details
//Logo, tên trong thẻ HOME PAGE, trang chính EcommerceWeb/Views/Shared/_Layout
Vào file Area/Views/Shared/_Layout để buid chức năng đăng nhập quản trị
Vào file EncommerceWeb/Views/Shared/_Layout để có thể đổi tiêu đề trang Web
*/
namespace EcommerceWeb.Controllers
{
    public class HomeController : Controller
    {
        EncommerceDBContext db = new EncommerceDBContext();
        public ActionResult Index()
        {
            ViewBag.ProductSelling = db.Products.OrderByDescending(x => x.Sale).Where(x=>x.Sale >0).ToList();
            ViewBag.AllProducts = db.Products.ToList();
            ViewBag.Comment = db.Feedbacks.ToList();
            ViewBag.NewProduct = db.Products.OrderByDescending(x => x.Update).Take(4).ToList();
           
            return View();
        }
        public ActionResult Comment()
        {
            ViewBag.Comment = db.Feedbacks.ToList();
            return View();
        }
        public ActionResult ProductSelling()
        {
            ViewBag.ProductSelling = db.Products.OrderByDescending(x => x.Sale).Where(x => x.Sale > 0).ToList();

            return View();
        }
        
        public ActionResult Details(int id)
        {
            //tìm sản phẩm theo mã
            Product sp = db.Products.SingleOrDefault(x => x.ID_Product == id);
            //nếu không tìm thấy
            if (sp == null)
            {
                return HttpNotFound();
            }
            return View(sp);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Login1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login1(string username, string password)
        {
            User user = db.Users.SingleOrDefault(x => x.UserName == username && x.Password == password);
            if (user != null)
            {
                Session["ID_User"] = user.ID_User;
                Session["UserName"] = user.UserName;
                Session["Email"] = user.Email;
                return RedirectToAction("Index");
            }
            ViewBag.error = "Incorrect the UserName or Password!";
            return View();
        }

        [HttpGet]
        public ActionResult Register1()
        {
            return View();
        }
        //Register
        [HttpPost]
        public ActionResult Register1(User _user)//string username, string password, string email, string phonenumber, DateTime birth)
        {
            if (ModelState.IsValid)
            {
                var check = db.Users.FirstOrDefault(s => s.Email == _user.Email);
                if (check == null)
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Users.Add(_user);
                    db.SaveChanges();
                    //nếu đăng ký thành công thì quay lại trang đăng nhập
                    return RedirectToAction("Login1");
                }
                else
                {
                    ViewBag.error = "Email already exists! Use another email please!!!";
                    return View();
                }
            }
            return View();
        }
        public JsonResult CategoryProduct(int ID_Catergory)
        {
            var result = (from p in db.Products
                          where p.ID_Category == ID_Catergory
                          select new
                          {
                              ID_Product = p.ID_Product,
                              ProductName = p.ProductName,
                              Image = p.Image,
                              Price = p.Price,
                              Sale = p.Sale, 
                              Origin = p.Origin,
                              Unit = p.Unit,
                              DateManufacture = p.DateManufacture,
                              ExpirpationDate = p.ExpirationDate,
                              Description = p.Description,
                              DescriptionDTS = p.DescriptionDTS,
                              Update = p.Update
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CategoryPartical()
        {
            return PartialView(db.Categories.OrderBy(n => n.CategoryName).ToList());
        }
        public ActionResult NewProduct()
        {
            ViewBag.NewProduct = db.Products.OrderByDescending(x => x.Update).Take(4).ToList();

            return View();
        }

        //public ActionResult ShowCategory()
        //{
        //    return true;
        //}
    }
}