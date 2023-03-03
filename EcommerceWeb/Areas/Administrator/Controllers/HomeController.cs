using Encommerce_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EcommerceWeb.Areas.Administrator.Controllers
{

    public class HomeController : Controller
    {
        EncommerceDBContext db = new EncommerceDBContext();
        // GET: Administrator/Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
           // User user = db.Users.SingleOrDefault(x => x.UserName == username && x.Password == password);
            if (username != null && password != null)
            {
                if(username == "VanLam" && password == "lamnv1901")
                //Session["ID_User"] = user.ID_User;
                //Session["UserName"] = user.UserName;
                //Session["Email"] = user.Email;
                return RedirectToAction("Index");
            }
            ViewBag.error = "Incorrect the UserName or Password!";
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        //Register
        [HttpPost]
        public ActionResult Register(User _user)//string username, string password, string email, string phonenumber, DateTime birth)
        {
           if(ModelState.IsValid)
            {
                var check = db.Users.FirstOrDefault(s => s.Email == _user.Email);
                    if (check == null)
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Users.Add(_user);
                    db.SaveChanges();
                    //nếu đăng ký thành công thì quay lại trang đăng nhập
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.error = "Email already exists! Use another email please!!!";
                    return View();
                }
                
            }
            return View();
        }
        public ActionResult Detail1()
        {
            User user = db.Users.SingleOrDefault(x => x.UserName == "VanLam" && x.Password == "lamnv1901");
                return RedirectToAction("Index");
        }

        public ActionResult Introduce()
        {
            return View();
        }
    }
}