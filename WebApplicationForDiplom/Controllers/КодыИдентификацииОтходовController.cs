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
    public class КодыИдентификацииОтходовController : ApiController
    {
        private diplomEntities1 db = new diplomEntities1();

        // GET: api/КодыИдентификацииОтходов
        public IQueryable<КодыИдентификацииОтходов> GetКодыИдентификацииОтходов()
        {
            return db.КодыИдентификацииОтходов;
        }

        // GET: api/КодыИдентификацииОтходов/5
        [Authorize]
        [ResponseType(typeof(КодыИдентификацииОтходов))]
        public async Task<IHttpActionResult> GetКодыИдентификацииОтходов(int id)
        {
            КодыИдентификацииОтходов кодыИдентификацииОтходов = await db.КодыИдентификацииОтходов.FindAsync(id);
            if (кодыИдентификацииОтходов == null)
            {
                return NotFound();
            }

            return Ok(кодыИдентификацииОтходов);
        }

        // PUT: api/КодыИдентификацииОтходов/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutКодыИдентификацииОтходов(int id, КодыИдентификацииОтходов кодыИдентификацииОтходов)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != кодыИдентификацииОтходов.IdКода)
            {
                return BadRequest();
            }

            db.Entry(кодыИдентификацииОтходов).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!КодыИдентификацииОтходовExists(id))
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

        // POST: api/КодыИдентификацииОтходов
        [ResponseType(typeof(КодыИдентификацииОтходов))]
        public async Task<IHttpActionResult> PostКодыИдентификацииОтходов(КодыИдентификацииОтходов кодыИдентификацииОтходов)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.КодыИдентификацииОтходов.Add(кодыИдентификацииОтходов);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = кодыИдентификацииОтходов.IdКода }, кодыИдентификацииОтходов);
        }

        // DELETE: api/КодыИдентификацииОтходов/5
        [ResponseType(typeof(КодыИдентификацииОтходов))]
        public async Task<IHttpActionResult> DeleteКодыИдентификацииОтходов(int id)
        {
            КодыИдентификацииОтходов кодыИдентификацииОтходов = await db.КодыИдентификацииОтходов.FindAsync(id);
            if (кодыИдентификацииОтходов == null)
            {
                return NotFound();
            }

            db.КодыИдентификацииОтходов.Remove(кодыИдентификацииОтходов);
            await db.SaveChangesAsync();

            return Ok(кодыИдентификацииОтходов);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool КодыИдентификацииОтходовExists(int id)
        {
            return db.КодыИдентификацииОтходов.Count(e => e.IdКода == id) > 0;
        }
    }
}