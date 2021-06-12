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
    public class Партии_отходовController : ApiController
    {
        private diplomEntities2 db = new diplomEntities2();

        // GET: api/Партии_отходов/5
        [ResponseType(typeof(Партии_отходов))]
        public async Task<IHttpActionResult> GetПартии_отходов(int id)
        {
            Партии_отходов партии_отходов = await db.Партии_отходов.FindAsync(id);
            if (партии_отходов == null)
            {
                return NotFound();
            }

            return Ok(партии_отходов);
        }

        // PUT: api/Партии_отходов/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutПартии_отходов(int id, Партии_отходов партии_отходов)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != партии_отходов.Id_партии_отходов)
            {
                return BadRequest();
            }

            db.Entry(партии_отходов).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Партии_отходовExists(id))
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

        // POST: api/Партии_отходов
        [ResponseType(typeof(Партии_отходов))]
        public async Task<IHttpActionResult> PostПартии_отходов(Партии_отходов партии_отходов)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Партии_отходов.Add(партии_отходов);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = партии_отходов.Id_партии_отходов }, партии_отходов);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Партии_отходовExists(int id)
        {
            return db.Партии_отходов.Count(e => e.Id_партии_отходов == id) > 0;
        }
    }
}