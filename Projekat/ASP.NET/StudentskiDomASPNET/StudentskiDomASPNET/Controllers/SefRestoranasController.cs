using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentskiDomASPNET.Models;

namespace StudentskiDomASPNET.Controllers
{
    public class SefRestoranasController : Controller
    {
        private StudentskiDomContext db = new StudentskiDomContext();

        // GET: SefRestoranas
        public ActionResult Index()
        {
            return View(db.SefRestorana.ToList());
        }

        // GET: SefRestoranas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SefRestorana sefRestorana = db.SefRestorana.Find(id);
            if (sefRestorana == null)
            {
                return HttpNotFound();
            }
            return View(sefRestorana);
        }

        // GET: SefRestoranas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SefRestoranas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SefRestoranaId,Plata,BankovniRacun,Ime,Prezime,DatumRodjenja,Username,Password,Jmbg")] SefRestorana sefRestorana)
        {
            if (ModelState.IsValid)
            {
                db.SefRestorana.Add(sefRestorana);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sefRestorana);
        }

        // GET: SefRestoranas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SefRestorana sefRestorana = db.SefRestorana.Find(id);
            if (sefRestorana == null)
            {
                return HttpNotFound();
            }
            return View(sefRestorana);
        }

        // POST: SefRestoranas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SefRestoranaId,Plata,BankovniRacun,Ime,Prezime,DatumRodjenja,Username,Password,Jmbg")] SefRestorana sefRestorana)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sefRestorana).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sefRestorana);
        }

        // GET: SefRestoranas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SefRestorana sefRestorana = db.SefRestorana.Find(id);
            if (sefRestorana == null)
            {
                return HttpNotFound();
            }
            return View(sefRestorana);
        }

        // POST: SefRestoranas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SefRestorana sefRestorana = db.SefRestorana.Find(id);
            db.SefRestorana.Remove(sefRestorana);
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
