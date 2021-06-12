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
    public class Собранные_отходы_клиентовController : ApiController
    {
        private diplomEntities2 db = new diplomEntities2();
        // POST: api/Собранные_отходы_клиентов
        [ResponseType(typeof(Собранные_отходы_клиентов))]
        public async Task<IHttpActionResult> PostСобранные_отходы_клиентов(Собранные_отходы_клиентов собранные_отходы_клиентов)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Ищем запись с кодом, по коду
            Коды_отходов musorCods = db.Коды_отходов.Where(b => b.Id_Кода == собранные_отходы_клиентов.Id_Кода).First();
            int i = musorCods.Количество;
            // Проверяем не превышино ли количетво записей
            IQueryable<Собранные_отходы_клиентов> Sobr = db.Собранные_отходы_клиентов.Where(b => b.Id_Кода == musorCods.Id_Кода);
            if (Sobr.Count() >= i)
                return BadRequest("Количестов записей по этому коду превышенно! Обратитесь к администратору!");
            db.Собранные_отходы_клиентов.Add(собранные_отходы_клиентов);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = собранные_отходы_клиентов.Id_Отходов_по_коду }, собранные_отходы_клиентов);
        }

        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Собранные_отходы_клиентовExists(int id)
        {
            return db.Собранные_отходы_клиентов.Count(e => e.Id_Отходов_по_коду == id) > 0;
        }
    }
}