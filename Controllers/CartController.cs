using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eticaret.Models.Classes;

namespace eticaret.Controllers
{
    
    public class CartController : Controller
    {
        Context c = new Context();
        // GET: Cart
        public ActionResult Index(int id)
        {
            var degerler = c.Ürüns.Where(x => x.ÜrünID == id ).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult Dogrulama()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Dogrulama(Cart p)
        {
            c.Carts.Add(p);
            c.SaveChanges();
            return RedirectToAction("Onay");
        }

        public ActionResult Onay()
        {

            return View();
        }




    }
}