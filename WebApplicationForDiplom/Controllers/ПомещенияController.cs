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
    public class ПомещенияController : ApiController
    {
        private diplomEntities db = new diplomEntities();

        // GET: api/Помещения
        public IQueryable<Помещения> GetПомещения()
        {
            return db.Помещения;
        }

        // GET: api/Помещения/5
        [ResponseType(typeof(Помещения))]
        public async Task<IHttpActionResult> GetПомещения(int id)
        {
            Помещения помещения = await db.Помещения.FindAsync(id);
            if (помещения == null)
            {
                return NotFound();
            }

            return Ok(помещения);
        }

        // PUT: api/Помещения/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutПомещения(int id, Помещения помещения)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != помещения.IdПомещения)
            {
                return BadRequest();
            }

            db.Entry(помещения).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ПомещенияExists(id))
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

        // POST: api/Помещения
        [ResponseType(typeof(Помещения))]
        public async Task<IHttpActionResult> PostПомещения(Помещения помещения)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Помещения.Add(помещения);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = помещения.IdПомещения }, помещения);
        }

        // DELETE: api/Помещения/5
        [ResponseType(typeof(Помещения))]
        public async Task<IHttpActionResult> DeleteПомещения(int id)
        {
            Помещения помещения = await db.Помещения.FindAsync(id);
            if (помещения == null)
            {
                return NotFound();
            }

            db.Помещения.Remove(помещения);
            await db.SaveChangesAsync();

            return Ok(помещения);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ПомещенияExists(int id)
        {
            return db.Помещения.Count(e => e.IdПомещения == id) > 0;
        }
    }
}