using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eticaret.Models.Classes;

namespace eticaret.Controllers
{
    public class ContactController : Controller
    {
        Context c = new Context();
        // GET: Contact
        [HttpGet]
        public ActionResult Index()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Index(Contact a)
        {
            c.Contacts.Add(a);
            c.SaveChanges();
            return RedirectToAction("Onay");
        }

        public ActionResult Onay()
        {
            return View();
        }
    }
}