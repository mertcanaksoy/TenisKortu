using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TenisProjesi;

namespace TenisProjesi.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SaatsController : Controller
    {
        private TenisProjesiEntities db = new TenisProjesiEntities();

        // GET: Admin/Saats
        public ActionResult Index()
        {
            return View(db.Saats.ToList());
        }

        // GET: Admin/Saats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Saat saat = db.Saats.Find(id);
            if (saat == null)
            {
                return HttpNotFound();
            }
            return View(saat);
        }

        // GET: Admin/Saats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Saats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,kortId,tarih,baslangicSaati,bitisSaati")] Saat saat)
        {
            if (ModelState.IsValid)
            {
                db.Saats.Add(saat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(saat);
        }

        // GET: Admin/Saats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Saat saat = db.Saats.Find(id);
            if (saat == null)
            {
                return HttpNotFound();
            }
            return View(saat);
        }

        // POST: Admin/Saats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,kortId,tarih,baslangicSaati,bitisSaati")] Saat saat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(saat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(saat);
        }

        // GET: Admin/Saats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Saat saat = db.Saats.Find(id);
            if (saat == null)
            {
                return HttpNotFound();
            }
            return View(saat);
        }

        // POST: Admin/Saats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Saat saat = db.Saats.Find(id);
            db.Saats.Remove(saat);
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
