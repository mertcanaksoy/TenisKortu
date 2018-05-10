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
    public class KortsController : Controller
    {
        private TenisProjesiEntities db = new TenisProjesiEntities();

        // GET: Admin/Korts
        public ActionResult Index()
        {
            return View(db.Korts.ToList());
        }

        // GET: Admin/Korts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kort kort = db.Korts.Find(id);
            if (kort == null)
            {
                return HttpNotFound();
            }
            return View(kort);
        }

        // GET: Admin/Korts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Korts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,kortAdi,fiyat")] Kort kort)
        {
            if (ModelState.IsValid)
            {
                db.Korts.Add(kort);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kort);
        }

        // GET: Admin/Korts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kort kort = db.Korts.Find(id);
            if (kort == null)
            {
                return HttpNotFound();
            }
            return View(kort);
        }

        // POST: Admin/Korts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,kortAdi,fiyat")] Kort kort)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kort).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kort);
        }

        // GET: Admin/Korts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kort kort = db.Korts.Find(id);
            if (kort == null)
            {
                return HttpNotFound();
            }
            return View(kort);
        }

        // POST: Admin/Korts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kort kort = db.Korts.Find(id);
            db.Korts.Remove(kort);
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
