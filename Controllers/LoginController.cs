using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using eticaret.Models.Classes;

namespace eticaret.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Öğrenci p)
        {
            var bilgiler = c.Öğrencis.FirstOrDefault(x => x.ÖğrenciEmail == p.ÖğrenciEmail && x.ÖğrenciSifre == p.ÖğrenciSifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.ÖğrenciEmail, false);
                Session["ÖğrenciAdı"] = bilgiler.ÖğrenciAdı.ToString();
                return RedirectToAction("ÜrünEkle", "ÖğrenciPanel");
            }

            else
            {
                return RedirectToAction("Index","Login");
            }
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Register(Öğrenci p)
        {
            c.Öğrencis.Add(p);
            c.SaveChanges();
            return RedirectToAction("RegisterOnay");
        }

        public ActionResult RegisterOnay()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.Kadi == p.Kadi && x.Sifre == p.Sifre);
            if (bilgiler!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Kadi, false);
                Session["Kadi"] = bilgiler.Kadi.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }


        
    }
}