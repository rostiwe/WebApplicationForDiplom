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
    [Authorize(Roles = "Admin, PoliMen, SborMen")]
    public class ОтходыПоКодуController : ApiController
    {
        private diplomEntities1 db = new diplomEntities1();

        // GET: api/ОтходыПоКоду
        public IQueryable<ОтходыПоКоду> GetОтходыПоКоду()
        {
            return db.ОтходыПоКоду;
        }

        // GET: api/ОтходыПоКоду/5
        [ResponseType(typeof(ОтходыПоКоду))]
        public async Task<IHttpActionResult> GetОтходыПоКоду(int id)
        {
            ОтходыПоКоду отходыПоКоду = await db.ОтходыПоКоду.FindAsync(id);
            if (отходыПоКоду == null)
            {
                return NotFound();
            }

            return Ok(отходыПоКоду);
        }

        // PUT: api/ОтходыПоКоду/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutОтходыПоКоду(int id, ОтходыПоКоду отходыПоКоду)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != отходыПоКоду.IdОтходовПоКоду)
            {
                return BadRequest();
            }

            db.Entry(отходыПоКоду).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ОтходыПоКодуExists(id))
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

        // POST: api/ОтходыПоКоду
        [ResponseType(typeof(ОтходыПоКоду))]
        public async Task<IHttpActionResult> PostОтходыПоКоду(ОтходыПоКоду отходыПоКоду)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ОтходыПоКоду.Add(отходыПоКоду);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = отходыПоКоду.IdОтходовПоКоду }, отходыПоКоду);
        }

        // DELETE: api/ОтходыПоКоду/5
        [ResponseType(typeof(ОтходыПоКоду))]
        public async Task<IHttpActionResult> DeleteОтходыПоКоду(int id)
        {
            ОтходыПоКоду отходыПоКоду = await db.ОтходыПоКоду.FindAsync(id);
            if (отходыПоКоду == null)
            {
                return NotFound();
            }

            db.ОтходыПоКоду.Remove(отходыПоКоду);
            await db.SaveChangesAsync();

            return Ok(отходыПоКоду);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ОтходыПоКодуExists(int id)
        {
            return db.ОтходыПоКоду.Count(e => e.IdОтходовПоКоду == id) > 0;
        }
    }
}