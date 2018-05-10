using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TenisProjesi.Controllers
{
    [Authorize(Roles ="User")]
    public class UserController : Controller
    {
        private TenisProjesiEntities db = new TenisProjesiEntities();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Faturalandirma()
        {
            int id = User.Identity.GetUserId<int>();
            var model = db.Faturas.Where(m => m.kiralamaId == id);
            return View(model);
        }
        public ActionResult Aboneliklerim()
        {
            int id = User.Identity.GetUserId<int>();
            var model = db.Aboneliklers.Where(m => m.User_Id == id);
            return View(model);
        }

    }
}