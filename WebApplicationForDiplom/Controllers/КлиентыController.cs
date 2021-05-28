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
    public class КлиентыController : ApiController
    {
        private diplomEntities1 db = new diplomEntities1();

        // GET: api/Клиенты
        public IQueryable<Клиенты> GetКлиенты()
        {
            return db.Клиенты;
        }

        // GET: api/Клиенты/5
        [ResponseType(typeof(Клиенты))]
        public async Task<IHttpActionResult> GetКлиенты(int id)
        {
            Клиенты клиенты = await db.Клиенты.FindAsync(id);
            if (клиенты == null)
            {
                return NotFound();
            }

            return Ok(клиенты);
        }

        // PUT: api/Клиенты/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutКлиенты(int id, Клиенты клиенты)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != клиенты.IdКлиента)
            {
                return BadRequest();
            }

            db.Entry(клиенты).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!КлиентыExists(id))
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

        // POST: api/Клиенты
        [ResponseType(typeof(Клиенты))]
        public async Task<IHttpActionResult> PostКлиенты(Клиенты клиенты)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Клиенты.Add(клиенты);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = клиенты.IdКлиента }, клиенты);
        }

        // DELETE: api/Клиенты/5
        [ResponseType(typeof(Клиенты))]
        public async Task<IHttpActionResult> DeleteКлиенты(int id)
        {
            Клиенты клиенты = await db.Клиенты.FindAsync(id);
            if (клиенты == null)
            {
                return NotFound();
            }

            db.Клиенты.Remove(клиенты);
            await db.SaveChangesAsync();

            return Ok(клиенты);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool КлиентыExists(int id)
        {
            return db.Клиенты.Count(e => e.IdКлиента == id) > 0;
        }
    }
}