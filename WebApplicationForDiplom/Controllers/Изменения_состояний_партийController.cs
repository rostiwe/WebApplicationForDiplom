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
    public class Изменения_состояний_партийController : ApiController
    {
        private diplomEntities2 db = new diplomEntities2();

        

        // POST: api/Изменения_состояний_партий
        [ResponseType(typeof(Изменения_состояний_партий))]
        public async Task<IHttpActionResult> PostИзменения_состояний_партий(Изменения_состояний_партий изменения_состояний_партий)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Изменения_состояний_партий.Add(изменения_состояний_партий);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Изменения_состояний_партийExists(изменения_состояний_партий.Id_Состояния))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = изменения_состояний_партий.Id_Состояния }, изменения_состояний_партий);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Изменения_состояний_партийExists(int id)
        {
            return db.Изменения_состояний_партий.Count(e => e.Id_Состояния == id) > 0;
        }
    }
}