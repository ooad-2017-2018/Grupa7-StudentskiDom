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
    public class BlagajniksController : Controller
    {
        private StudentskiDomContext db = new StudentskiDomContext();

        // GET: Blagajniks
        string apiURL = "http://studentskidomwebapi.azurewebsites.net/";
        public async Task<ActionResult> Index()
        {
            List<Blagajnik> blagajnici = new List<Blagajnik>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiURL);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("api/Blagajniks");

                if (res.IsSuccessStatusCode)
                {
                    var response = res.Content.ReadAsStringAsync().Result;
                    blagajnici = JsonConvert.DeserializeObject<List<Blagajnik>>(response);

                }
            }
            return View(blagajnici);
        }

        // GET: Blagajniks/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blagajnik blagajnik = db.Blagajnik.Find(id);
            if (blagajnik == null)
            {
                return HttpNotFound();
            }
            return View(blagajnik);
        }

        // GET: Blagajniks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blagajniks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BlagajnikId,Plata,BankovniRacun,Ime,Prezime,DatumRodjenja,Username,Password,Jmbg")] Blagajnik blagajnik)
        {
            if (ModelState.IsValid)
            {
                db.Blagajnik.Add(blagajnik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blagajnik);
        }

        // GET: Blagajniks/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blagajnik blagajnik = db.Blagajnik.Find(id);
            if (blagajnik == null)
            {
                return HttpNotFound();
            }
            return View(blagajnik);
        }

        // POST: Blagajniks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BlagajnikId,Plata,BankovniRacun,Ime,Prezime,DatumRodjenja,Username,Password,Jmbg")] Blagajnik blagajnik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blagajnik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blagajnik);
        }

        // GET: Blagajniks/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blagajnik blagajnik = db.Blagajnik.Find(id);
            if (blagajnik == null)
            {
                return HttpNotFound();
            }
            return View(blagajnik);
        }

        // POST: Blagajniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Blagajnik blagajnik = db.Blagajnik.Find(id);
            db.Blagajnik.Remove(blagajnik);
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
