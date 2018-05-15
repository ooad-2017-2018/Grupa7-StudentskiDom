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
    public class MajstorsController : ApiController
    {
        private SDomModel db = new SDomModel();

        // GET: api/Majstors
        public IQueryable<Majstor> GetMajstor()
        {
            return db.Majstor;
        }

        // GET: api/Majstors/5
        [ResponseType(typeof(Majstor))]
        public async Task<IHttpActionResult> GetMajstor(string id)
        {
            Majstor majstor = await db.Majstor.FindAsync(id);
            if (majstor == null)
            {
                return NotFound();
            }

            return Ok(majstor);
        }

        // PUT: api/Majstors/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMajstor(string id, Majstor majstor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != majstor.id)
            {
                return BadRequest();
            }

            db.Entry(majstor).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MajstorExists(id))
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

        // POST: api/Majstors
        [ResponseType(typeof(Majstor))]
        public async Task<IHttpActionResult> PostMajstor(Majstor majstor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Majstor.Add(majstor);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MajstorExists(majstor.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = majstor.id }, majstor);
        }

        // DELETE: api/Majstors/5
        [ResponseType(typeof(Majstor))]
        public async Task<IHttpActionResult> DeleteMajstor(string id)
        {
            Majstor majstor = await db.Majstor.FindAsync(id);
            if (majstor == null)
            {
                return NotFound();
            }

            db.Majstor.Remove(majstor);
            await db.SaveChangesAsync();

            return Ok(majstor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MajstorExists(string id)
        {
            return db.Majstor.Count(e => e.id == id) > 0;
        }
    }
}