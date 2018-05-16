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
    public class MajstorsController : Controller
    {
        private StudentskiDomContext db = new StudentskiDomContext();

        // GET: Majstors
        string apiURL = "http://studentskidomwebapi.azurewebsites.net/";
        public async Task<ActionResult> Index()
        {
            List<Majstor> majstori = new List<Majstor>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiURL);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("api/SefRestoranas");

                if (res.IsSuccessStatusCode)
                {
                    var response = res.Content.ReadAsStringAsync().Result;
                    majstori = JsonConvert.DeserializeObject<List<Majstor>>(response);

                }
            }
            return View(majstori);
        }

        // GET: Majstors/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Majstor majstor = db.Majstor.Find(id);
            if (majstor == null)
            {
                return HttpNotFound();
            }
            return View(majstor);
        }

        // GET: Majstors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Majstors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MajstorId,Tip,Plata,BankovniRacun,Ime,Prezime,DatumRodjenja,Username,Password,Jmbg")] Majstor majstor)
        {
            if (ModelState.IsValid)
            {
                db.Majstor.Add(majstor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(majstor);
        }

        // GET: Majstors/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Majstor majstor = db.Majstor.Find(id);
            if (majstor == null)
            {
                return HttpNotFound();
            }
            return View(majstor);
        }

        // POST: Majstors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MajstorId,Tip,Plata,BankovniRacun,Ime,Prezime,DatumRodjenja,Username,Password,Jmbg")] Majstor majstor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(majstor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(majstor);
        }

        // GET: Majstors/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Majstor majstor = db.Majstor.Find(id);
            if (majstor == null)
            {
                return HttpNotFound();
            }
            return View(majstor);
        }

        // POST: Majstors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Majstor majstor = db.Majstor.Find(id);
            db.Majstor.Remove(majstor);
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
