using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using StudentskiDomASPNET.Models;

namespace StudentskiDomASPNET.Controllers
{
    public class KonobarsController : Controller
    {
        private StudentskiDomContext db = new StudentskiDomContext();

        // GET: Konobars
        string apiURL = "http://studentskidomwebapi.azurewebsites.net/";
        public async Task<ActionResult> Index()
        {
            List<Konobar> konobari = new List<Konobar>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiURL);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("api/SefRestoranas");

                if (res.IsSuccessStatusCode)
                {
                    var response = res.Content.ReadAsStringAsync().Result;
                    konobari = JsonConvert.DeserializeObject<List<Konobar>>(response);

                }
            }
            return View(konobari);
        }

        // GET: Konobars/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Konobar konobar = db.Konobar.Find(id);
            if (konobar == null)
            {
                return HttpNotFound();
            }
            return View(konobar);
        }

        // GET: Konobars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Konobars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KonobarId,Plata,BankovniRacun,Ime,Prezime,DatumRodjenja,Username,Password,Jmbg")] Konobar konobar)
        {
            if (ModelState.IsValid)
            {
                db.Konobar.Add(konobar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(konobar);
        }

        // GET: Konobars/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Konobar konobar = db.Konobar.Find(id);
            if (konobar == null)
            {
                return HttpNotFound();
            }
            return View(konobar);
        }

        // POST: Konobars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KonobarId,Plata,BankovniRacun,Ime,Prezime,DatumRodjenja,Username,Password,Jmbg")] Konobar konobar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(konobar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(konobar);
        }

        // GET: Konobars/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Konobar konobar = db.Konobar.Find(id);
            if (konobar == null)
            {
                return HttpNotFound();
            }
            return View(konobar);
        }

        // POST: Konobars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Konobar konobar = db.Konobar.Find(id);
            db.Konobar.Remove(konobar);
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
