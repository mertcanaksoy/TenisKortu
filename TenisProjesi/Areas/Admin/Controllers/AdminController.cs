using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TenisProjesi.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private TenisProjesiEntities db = new TenisProjesiEntities();
        // GET: Admin/Default
        public ActionResult Index()
        {
            int id= User.Identity.GetUserId<int>();
            var model = db.AspNetUsers.Where(m => m.Id == id);
            return View(model);
        }
    }
}