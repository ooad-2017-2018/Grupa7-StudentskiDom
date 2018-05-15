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
    public class StudentsController : ApiController
    {
        private SDomModel db = new SDomModel();

        // GET: api/Students
        public IQueryable<Student> GetStudent()
        {
            return db.Student;
        }

        // GET: api/Students/5
        [ResponseType(typeof(Student))]
        public async Task<IHttpActionResult> GetStudent(string id)
        {
            Student student = await db.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // PUT: api/Students/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStudent(string id, Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student.id)
            {
                return BadRequest();
            }

            db.Entry(student).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
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

        // POST: api/Students
        [ResponseType(typeof(Student))]
        public async Task<IHttpActionResult> PostStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Student.Add(student);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StudentExists(student.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = student.id }, student);
        }

        // DELETE: api/Students/5
        [ResponseType(typeof(Student))]
        public async Task<IHttpActionResult> DeleteStudent(string id)
        {
            Student student = await db.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            db.Student.Remove(student);
            await db.SaveChangesAsync();

            return Ok(student);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentExists(string id)
        {
            return db.Student.Count(e => e.id == id) > 0;
        }
    }
}