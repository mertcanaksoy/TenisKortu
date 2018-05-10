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
    public class FaturaController : Controller
    {
        private TenisProjesiEntities db = new TenisProjesiEntities();

        // GET: Admin/Fatura
        public ActionResult Index()
        {
            var fatura = db.Faturas.Include(f => f.User_Kiralama);
            return View(fatura.ToList());
        }

        // GET: Admin/Fatura/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fatura fatura = db.Faturas.Find(id);
            if (fatura == null)
            {
                return HttpNotFound();
            }
            return View(fatura);
        }

        // GET: Admin/Fatura/Create
        public ActionResult Create()
        {
            ViewBag.kiralamaId = new SelectList(db.User_Kiralama, "Id", "Id");
            return View();
        }

        // POST: Admin/Fatura/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,kiralamaId,fiyat,kiralamaBaslangic,kiralamaBitis,faturaOdemeTarihi,is_deleted")] Fatura fatura)
        {
            if (ModelState.IsValid)
            {
                db.Faturas.Add(fatura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.kiralamaId = new SelectList(db.User_Kiralama, "Id", "Id", fatura.kiralamaId);
            return View(fatura);
        }

        // GET: Admin/Fatura/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fatura fatura = db.Faturas.Find(id);
            if (fatura == null)
            {
                return HttpNotFound();
            }
            ViewBag.kiralamaId = new SelectList(db.User_Kiralama, "Id", "Id", fatura.kiralamaId);
            return View(fatura);
        }

        // POST: Admin/Fatura/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,kiralamaId,fiyat,kiralamaBaslangic,kiralamaBitis,faturaOdemeTarihi,is_deleted")] Fatura fatura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fatura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.kiralamaId = new SelectList(db.User_Kiralama, "Id", "Id", fatura.kiralamaId);
            return View(fatura);
        }

        // GET: Admin/Fatura/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fatura fatura = db.Faturas.Find(id);
            if (fatura == null)
            {
                return HttpNotFound();
            }
            return View(fatura);
        }

        // POST: Admin/Fatura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fatura fatura = db.Faturas.Find(id);
            db.Faturas.Remove(fatura);
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
