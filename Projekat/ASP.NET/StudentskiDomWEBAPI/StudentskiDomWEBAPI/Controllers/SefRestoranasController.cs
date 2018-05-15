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
    public class SefRestoranasController : ApiController
    {
        private SDomModel db = new SDomModel();

        // GET: api/SefRestoranas
        public IQueryable<SefRestorana> GetSefRestorana()
        {
            return db.SefRestorana;
        }

        // GET: api/SefRestoranas/5
        [ResponseType(typeof(SefRestorana))]
        public async Task<IHttpActionResult> GetSefRestorana(string id)
        {
            SefRestorana sefRestorana = await db.SefRestorana.FindAsync(id);
            if (sefRestorana == null)
            {
                return NotFound();
            }

            return Ok(sefRestorana);
        }

        // PUT: api/SefRestoranas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSefRestorana(string id, SefRestorana sefRestorana)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sefRestorana.id)
            {
                return BadRequest();
            }

            db.Entry(sefRestorana).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SefRestoranaExists(id))
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

        // POST: api/SefRestoranas
        [ResponseType(typeof(SefRestorana))]
        public async Task<IHttpActionResult> PostSefRestorana(SefRestorana sefRestorana)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SefRestorana.Add(sefRestorana);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SefRestoranaExists(sefRestorana.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sefRestorana.id }, sefRestorana);
        }

        // DELETE: api/SefRestoranas/5
        [ResponseType(typeof(SefRestorana))]
        public async Task<IHttpActionResult> DeleteSefRestorana(string id)
        {
            SefRestorana sefRestorana = await db.SefRestorana.FindAsync(id);
            if (sefRestorana == null)
            {
                return NotFound();
            }

            db.SefRestorana.Remove(sefRestorana);
            await db.SaveChangesAsync();

            return Ok(sefRestorana);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SefRestoranaExists(string id)
        {
            return db.SefRestorana.Count(e => e.id == id) > 0;
        }
    }
}