using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TenisProjesi.Controllers
{
    public class kontrolsController : Controller
    {
        private TenisProjesiEntities db = new TenisProjesiEntities();
       
        public ActionResult Edit(int id)
        {
            var chekin = db.User_Kiralama.Find(id);
            chekin.chekin = true;
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }           
    }
}
