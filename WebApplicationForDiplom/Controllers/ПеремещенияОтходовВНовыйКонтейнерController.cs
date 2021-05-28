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
    public class ПеремещенияОтходовВНовыйКонтейнерController : ApiController
    {
        private diplomEntities db = new diplomEntities();

        // GET: api/ПеремещенияОтходовВНовыйКонтейнер
        public IQueryable<ПеремещенияОтходовВНовыйКонтейнер> GetПеремещенияОтходовВНовыйКонтейнер()
        {
            return db.ПеремещенияОтходовВНовыйКонтейнер;
        }

        // GET: api/ПеремещенияОтходовВНовыйКонтейнер/5
        [ResponseType(typeof(ПеремещенияОтходовВНовыйКонтейнер))]
        public async Task<IHttpActionResult> GetПеремещенияОтходовВНовыйКонтейнер(int id)
        {
            ПеремещенияОтходовВНовыйКонтейнер перемещенияОтходовВНовыйКонтейнер = await db.ПеремещенияОтходовВНовыйКонтейнер.FindAsync(id);
            if (перемещенияОтходовВНовыйКонтейнер == null)
            {
                return NotFound();
            }

            return Ok(перемещенияОтходовВНовыйКонтейнер);
        }

        // PUT: api/ПеремещенияОтходовВНовыйКонтейнер/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutПеремещенияОтходовВНовыйКонтейнер(int id, ПеремещенияОтходовВНовыйКонтейнер перемещенияОтходовВНовыйКонтейнер)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != перемещенияОтходовВНовыйКонтейнер.IdЗаписи)
            {
                return BadRequest();
            }

            db.Entry(перемещенияОтходовВНовыйКонтейнер).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ПеремещенияОтходовВНовыйКонтейнерExists(id))
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

        // POST: api/ПеремещенияОтходовВНовыйКонтейнер
        [ResponseType(typeof(ПеремещенияОтходовВНовыйКонтейнер))]
        public async Task<IHttpActionResult> PostПеремещенияОтходовВНовыйКонтейнер(ПеремещенияОтходовВНовыйКонтейнер перемещенияОтходовВНовыйКонтейнер)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ПеремещенияОтходовВНовыйКонтейнер.Add(перемещенияОтходовВНовыйКонтейнер);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = перемещенияОтходовВНовыйКонтейнер.IdЗаписи }, перемещенияОтходовВНовыйКонтейнер);
        }

        // DELETE: api/ПеремещенияОтходовВНовыйКонтейнер/5
        [ResponseType(typeof(ПеремещенияОтходовВНовыйКонтейнер))]
        public async Task<IHttpActionResult> DeleteПеремещенияОтходовВНовыйКонтейнер(int id)
        {
            ПеремещенияОтходовВНовыйКонтейнер перемещенияОтходовВНовыйКонтейнер = await db.ПеремещенияОтходовВНовыйКонтейнер.FindAsync(id);
            if (перемещенияОтходовВНовыйКонтейнер == null)
            {
                return NotFound();
            }

            db.ПеремещенияОтходовВНовыйКонтейнер.Remove(перемещенияОтходовВНовыйКонтейнер);
            await db.SaveChangesAsync();

            return Ok(перемещенияОтходовВНовыйКонтейнер);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ПеремещенияОтходовВНовыйКонтейнерExists(int id)
        {
            return db.ПеремещенияОтходовВНовыйКонтейнер.Count(e => e.IdЗаписи == id) > 0;
        }
    }
}