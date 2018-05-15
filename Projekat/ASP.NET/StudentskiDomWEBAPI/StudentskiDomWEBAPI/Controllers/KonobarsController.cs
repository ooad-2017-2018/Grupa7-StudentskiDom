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
    public class KonobarsController : ApiController
    {
        private SDomModel db = new SDomModel();

        // GET: api/Konobars
        public IQueryable<Konobar> GetKonobar()
        {
            return db.Konobar;
        }

        // GET: api/Konobars/5
        [ResponseType(typeof(Konobar))]
        public async Task<IHttpActionResult> GetKonobar(string id)
        {
            Konobar konobar = await db.Konobar.FindAsync(id);
            if (konobar == null)
            {
                return NotFound();
            }

            return Ok(konobar);
        }

        // PUT: api/Konobars/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutKonobar(string id, Konobar konobar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != konobar.id)
            {
                return BadRequest();
            }

            db.Entry(konobar).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KonobarExists(id))
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

        // POST: api/Konobars
        [ResponseType(typeof(Konobar))]
        public async Task<IHttpActionResult> PostKonobar(Konobar konobar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Konobar.Add(konobar);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KonobarExists(konobar.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = konobar.id }, konobar);
        }

        // DELETE: api/Konobars/5
        [ResponseType(typeof(Konobar))]
        public async Task<IHttpActionResult> DeleteKonobar(string id)
        {
            Konobar konobar = await db.Konobar.FindAsync(id);
            if (konobar == null)
            {
                return NotFound();
            }

            db.Konobar.Remove(konobar);
            await db.SaveChangesAsync();

            return Ok(konobar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KonobarExists(string id)
        {
            return db.Konobar.Count(e => e.id == id) > 0;
        }
    }
}