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
    public class AdminsController : ApiController
    {
        private SDomModel db = new SDomModel();

        // GET: api/Admins
        public IQueryable<Admin> GetAdmin()
        {
            return db.Admin;
        }

        // GET: api/Admins/5
        [ResponseType(typeof(Admin))]
        public async Task<IHttpActionResult> GetAdmin(string id)
        {
            Admin admin = await db.Admin.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }

            return Ok(admin);
        }

        // PUT: api/Admins/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAdmin(string id, Admin admin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != admin.id)
            {
                return BadRequest();
            }

            db.Entry(admin).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminExists(id))
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

        // POST: api/Admins
        [ResponseType(typeof(Admin))]
        public async Task<IHttpActionResult> PostAdmin(Admin admin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Admin.Add(admin);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AdminExists(admin.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = admin.id }, admin);
        }

        // DELETE: api/Admins/5
        [ResponseType(typeof(Admin))]
        public async Task<IHttpActionResult> DeleteAdmin(string id)
        {
            Admin admin = await db.Admin.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }

            db.Admin.Remove(admin);
            await db.SaveChangesAsync();

            return Ok(admin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdminExists(string id)
        {
            return db.Admin.Count(e => e.id == id) > 0;
        }
    }
}