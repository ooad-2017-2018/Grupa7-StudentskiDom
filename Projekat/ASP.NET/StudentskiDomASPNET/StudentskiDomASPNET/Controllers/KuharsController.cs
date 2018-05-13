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
    public class KuharsController : Controller
    {
        private StudentskiDomContext db = new StudentskiDomContext();

        // GET: Kuhars
        public ActionResult Index()
        {
            return View(db.Kuhar.ToList());
        }

        // GET: Kuhars/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kuhar kuhar = db.Kuhar.Find(id);
            if (kuhar == null)
            {
                return HttpNotFound();
            }
            return View(kuhar);
        }

        // GET: Kuhars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kuhars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KuharId,Plata,BankovniRacun,Ime,Prezime,DatumRodjenja,Username,Password,Jmbg")] Kuhar kuhar)
        {
            if (ModelState.IsValid)
            {
                db.Kuhar.Add(kuhar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kuhar);
        }

        // GET: Kuhars/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kuhar kuhar = db.Kuhar.Find(id);
            if (kuhar == null)
            {
                return HttpNotFound();
            }
            return View(kuhar);
        }

        // POST: Kuhars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KuharId,Plata,BankovniRacun,Ime,Prezime,DatumRodjenja,Username,Password,Jmbg")] Kuhar kuhar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kuhar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kuhar);
        }

        // GET: Kuhars/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kuhar kuhar = db.Kuhar.Find(id);
            if (kuhar == null)
            {
                return HttpNotFound();
            }
            return View(kuhar);
        }

        // POST: Kuhars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Kuhar kuhar = db.Kuhar.Find(id);
            db.Kuhar.Remove(kuhar);
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
