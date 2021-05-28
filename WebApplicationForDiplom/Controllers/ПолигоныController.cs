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
using WebApplicationForDiplom.Models;

namespace WebApplicationForDiplom.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ПолигоныController : ApiController
    {
        private diplomEntities db = new diplomEntities();

        // GET: api/Полигоны
        public IQueryable<Полигоны> GetПолигоны()
        {
            return db.Полигоны;
        }

        // GET: api/Полигоны/5
        [ResponseType(typeof(Полигоны))]
        public async Task<IHttpActionResult> GetПолигоны(int id)
        {
            Полигоны полигоны = await db.Полигоны.FindAsync(id);
            if (полигоны == null)
            {
                return NotFound();
            }

            return Ok(полигоны);
        }

        // PUT: api/Полигоны/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutПолигоны(int id, Полигоны полигоны)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != полигоны.IdПолигона)
            {
                return BadRequest();
            }

            db.Entry(полигоны).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ПолигоныExists(id))
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

        // POST: api/Полигоны
        [ResponseType(typeof(Полигоны))]
        public async Task<IHttpActionResult> PostПолигоны(Полигоны полигоны)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Полигоны.Add(полигоны);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = полигоны.IdПолигона }, полигоны);
        }

        // DELETE: api/Полигоны/5
        [ResponseType(typeof(Полигоны))]
        public async Task<IHttpActionResult> DeleteПолигоны(int id)
        {
            Полигоны полигоны = await db.Полигоны.FindAsync(id);
            if (полигоны == null)
            {
                return NotFound();
            }

            db.Полигоны.Remove(полигоны);
            await db.SaveChangesAsync();

            return Ok(полигоны);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ПолигоныExists(int id)
        {
            return db.Полигоны.Count(e => e.IdПолигона == id) > 0;
        }
    }
}