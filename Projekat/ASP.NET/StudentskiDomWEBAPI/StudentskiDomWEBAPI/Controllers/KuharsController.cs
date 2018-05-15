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
    public class KuharsController : ApiController
    {
        private SDomModel db = new SDomModel();

        // GET: api/Kuhars
        public IQueryable<Kuhar> GetKuhar()
        {
            return db.Kuhar;
        }

        // GET: api/Kuhars/5
        [ResponseType(typeof(Kuhar))]
        public async Task<IHttpActionResult> GetKuhar(string id)
        {
            Kuhar kuhar = await db.Kuhar.FindAsync(id);
            if (kuhar == null)
            {
                return NotFound();
            }

            return Ok(kuhar);
        }

        // PUT: api/Kuhars/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutKuhar(string id, Kuhar kuhar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kuhar.id)
            {
                return BadRequest();
            }

            db.Entry(kuhar).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KuharExists(id))
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

        // POST: api/Kuhars
        [ResponseType(typeof(Kuhar))]
        public async Task<IHttpActionResult> PostKuhar(Kuhar kuhar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kuhar.Add(kuhar);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KuharExists(kuhar.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = kuhar.id }, kuhar);
        }

        // DELETE: api/Kuhars/5
        [ResponseType(typeof(Kuhar))]
        public async Task<IHttpActionResult> DeleteKuhar(string id)
        {
            Kuhar kuhar = await db.Kuhar.FindAsync(id);
            if (kuhar == null)
            {
                return NotFound();
            }

            db.Kuhar.Remove(kuhar);
            await db.SaveChangesAsync();

            return Ok(kuhar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KuharExists(string id)
        {
            return db.Kuhar.Count(e => e.id == id) > 0;
        }
    }
}