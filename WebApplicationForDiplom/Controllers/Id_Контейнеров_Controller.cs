using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationForDiplom.Models;

namespace WebApplicationForDiplom.Controllers
{
    [Authorize(Roles = "Admin, PoliMen")]
    public class Id_Контейнеров_Controller : ApiController
    {
        // Ищем Id контейнера по его номеру
        diplomEntities2 db = new diplomEntities2();
        public string Get(string str)
        {
            try
            {
                Контейнер musorCods = db.Контейнер.Where(b => b.Номер_контейнера == str).First();
                return musorCods.Id_Контейнера.ToString();
            }
            catch
            {
                return "Контейнер не найден!";
            }
        }
    }
}
