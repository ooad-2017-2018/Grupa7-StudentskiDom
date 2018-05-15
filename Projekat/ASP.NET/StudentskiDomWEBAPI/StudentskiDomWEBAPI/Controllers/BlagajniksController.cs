using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using StudentskiDomWEBAPI.Models;

namespace StudentskiDomWEBAPI.Controllers
{
    public class BlagajniksController : ApiController
    {
        private SDomModel db = new SDomModel();

        // GET: api/Blagajniks
        public IQueryable<Blagajnik> GetBlagajnik()
        {
            return db.Blagajnik;
        }

        // GET: api/Blagajniks/5
        [ResponseType(typeof(Blagajnik))]
        public async Task<IHttpActionResult> GetBlagajnik(string id)
        {
            Blagajnik blagajnik = await db.Blagajnik.FindAsync(id);
            if (blagajnik == null)
            {
                return NotFound();
            }

            return Ok(blagajnik);
        }

        // PUT: api/Blagajniks/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBlagajnik(string id, Blagajnik blagajnik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != blagajnik.id)
            {
                return BadRequest();
            }

            db.Entry(blagajnik).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlagajnikExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Blagajniks
        [ResponseType(typeof(Blagajnik))]
        public async Task<IHttpActionResult> PostBlagajnik(Blagajnik blagajnik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Blagajnik.Add(blagajnik);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BlagajnikExists(blagajnik.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = blagajnik.id }, blagajnik);
        }

        // DELETE: api/Blagajniks/5
        [ResponseType(typeof(Blagajnik))]
        public async Task<IHttpActionResult> DeleteBlagajnik(string id)
        {
            Blagajnik blagajnik = await db.Blagajnik.FindAsync(id);
            if (blagajnik == null)
            {
                return NotFound();
            }

            db.Blagajnik.Remove(blagajnik);
            await db.SaveChangesAsync();

            return Ok(blagajnik);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BlagajnikExists(string id)
        {
            return db.Blagajnik.Count(e => e.id == id) > 0;
        }
    }
}