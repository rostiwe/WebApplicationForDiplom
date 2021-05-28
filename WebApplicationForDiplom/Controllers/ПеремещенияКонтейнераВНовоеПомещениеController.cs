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
    public class ПеремещенияКонтейнераВНовоеПомещениеController : ApiController
    {
        private diplomEntities db = new diplomEntities();

        // GET: api/ПеремещенияКонтейнераВНовоеПомещение
        public IQueryable<ПеремещенияКонтейнераВНовоеПомещение> GetПеремещенияКонтейнераВНовоеПомещение()
        {
            return db.ПеремещенияКонтейнераВНовоеПомещение;
        }

        // GET: api/ПеремещенияКонтейнераВНовоеПомещение/5
        [ResponseType(typeof(ПеремещенияКонтейнераВНовоеПомещение))]
        public async Task<IHttpActionResult> GetПеремещенияКонтейнераВНовоеПомещение(int id)
        {
            ПеремещенияКонтейнераВНовоеПомещение перемещенияКонтейнераВНовоеПомещение = await db.ПеремещенияКонтейнераВНовоеПомещение.FindAsync(id);
            if (перемещенияКонтейнераВНовоеПомещение == null)
            {
                return NotFound();
            }

            return Ok(перемещенияКонтейнераВНовоеПомещение);
        }

        // PUT: api/ПеремещенияКонтейнераВНовоеПомещение/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutПеремещенияКонтейнераВНовоеПомещение(int id, ПеремещенияКонтейнераВНовоеПомещение перемещенияКонтейнераВНовоеПомещение)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != перемещенияКонтейнераВНовоеПомещение.IdЗаписи)
            {
                return BadRequest();
            }

            db.Entry(перемещенияКонтейнераВНовоеПомещение).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ПеремещенияКонтейнераВНовоеПомещениеExists(id))
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

        // POST: api/ПеремещенияКонтейнераВНовоеПомещение
        [ResponseType(typeof(ПеремещенияКонтейнераВНовоеПомещение))]
        public async Task<IHttpActionResult> PostПеремещенияКонтейнераВНовоеПомещение(ПеремещенияКонтейнераВНовоеПомещение перемещенияКонтейнераВНовоеПомещение)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ПеремещенияКонтейнераВНовоеПомещение.Add(перемещенияКонтейнераВНовоеПомещение);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = перемещенияКонтейнераВНовоеПомещение.IdЗаписи }, перемещенияКонтейнераВНовоеПомещение);
        }

        // DELETE: api/ПеремещенияКонтейнераВНовоеПомещение/5
        [ResponseType(typeof(ПеремещенияКонтейнераВНовоеПомещение))]
        public async Task<IHttpActionResult> DeleteПеремещенияКонтейнераВНовоеПомещение(int id)
        {
            ПеремещенияКонтейнераВНовоеПомещение перемещенияКонтейнераВНовоеПомещение = await db.ПеремещенияКонтейнераВНовоеПомещение.FindAsync(id);
            if (перемещенияКонтейнераВНовоеПомещение == null)
            {
                return NotFound();
            }

            db.ПеремещенияКонтейнераВНовоеПомещение.Remove(перемещенияКонтейнераВНовоеПомещение);
            await db.SaveChangesAsync();

            return Ok(перемещенияКонтейнераВНовоеПомещение);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ПеремещенияКонтейнераВНовоеПомещениеExists(int id)
        {
            return db.ПеремещенияКонтейнераВНовоеПомещение.Count(e => e.IdЗаписи == id) > 0;
        }
    }
}