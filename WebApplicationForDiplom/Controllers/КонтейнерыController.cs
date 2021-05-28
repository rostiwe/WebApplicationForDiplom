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
    public class КонтейнерыController : ApiController
    {
        private diplomEntities db = new diplomEntities();

        // GET: api/Контейнеры
        public IQueryable<Контейнеры> GetКонтейнеры()
        {
            return db.Контейнеры;
        }

        // GET: api/Контейнеры/5
        [ResponseType(typeof(Контейнеры))]
        public async Task<IHttpActionResult> GetКонтейнеры(int id)
        {
            Контейнеры контейнеры = await db.Контейнеры.FindAsync(id);
            if (контейнеры == null)
            {
                return NotFound();
            }

            return Ok(контейнеры);
        }

        // PUT: api/Контейнеры/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutКонтейнеры(int id, Контейнеры контейнеры)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != контейнеры.IdКонтейнера)
            {
                return BadRequest();
            }

            db.Entry(контейнеры).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!КонтейнерыExists(id))
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

        // POST: api/Контейнеры
        [ResponseType(typeof(Контейнеры))]
        public async Task<IHttpActionResult> PostКонтейнеры(Контейнеры контейнеры)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Контейнеры.Add(контейнеры);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = контейнеры.IdКонтейнера }, контейнеры);
        }

        // DELETE: api/Контейнеры/5
        [ResponseType(typeof(Контейнеры))]
        public async Task<IHttpActionResult> DeleteКонтейнеры(int id)
        {
            Контейнеры контейнеры = await db.Контейнеры.FindAsync(id);
            if (контейнеры == null)
            {
                return NotFound();
            }

            db.Контейнеры.Remove(контейнеры);
            await db.SaveChangesAsync();

            return Ok(контейнеры);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool КонтейнерыExists(int id)
        {
            return db.Контейнеры.Count(e => e.IdКонтейнера == id) > 0;
        }
    }
}