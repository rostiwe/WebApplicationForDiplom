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
    [Authorize(Roles = "Admin, PoliMen")]
    public class ПартииОтходовController : ApiController
    {
        private diplomEntities db = new diplomEntities();

        // GET: api/ПартииОтходов
        public IQueryable<ПартииОтходов> GetПартииОтходов()
        {
            return db.ПартииОтходов;
        }

        // GET: api/ПартииОтходов/5
        [ResponseType(typeof(ПартииОтходов))]
        public async Task<IHttpActionResult> GetПартииОтходов(int id)
        {
            ПартииОтходов партииОтходов = await db.ПартииОтходов.FindAsync(id);
            if (партииОтходов == null)
            {
                return NotFound();
            }

            return Ok(партииОтходов);
        }

        // PUT: api/ПартииОтходов/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutПартииОтходов(int id, ПартииОтходов партииОтходов)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != партииОтходов.IdПартииОтходов)
            {
                return BadRequest();
            }

            db.Entry(партииОтходов).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ПартииОтходовExists(id))
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

        // POST: api/ПартииОтходов
        [ResponseType(typeof(ПартииОтходов))]
        public async Task<IHttpActionResult> PostПартииОтходов(ПартииОтходов партииОтходов)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ПартииОтходов.Add(партииОтходов);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = партииОтходов.IdПартииОтходов }, партииОтходов);
        }

        // DELETE: api/ПартииОтходов/5
        [ResponseType(typeof(ПартииОтходов))]
        public async Task<IHttpActionResult> DeleteПартииОтходов(int id)
        {
            ПартииОтходов партииОтходов = await db.ПартииОтходов.FindAsync(id);
            if (партииОтходов == null)
            {
                return NotFound();
            }

            db.ПартииОтходов.Remove(партииОтходов);
            await db.SaveChangesAsync();

            return Ok(партииОтходов);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ПартииОтходовExists(int id)
        {
            return db.ПартииОтходов.Count(e => e.IdПартииОтходов == id) > 0;
        }
    }
}