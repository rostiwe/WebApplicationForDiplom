using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationForDiplom.Models;

namespace WebApplicationForDiplom.Controllers
{
    //Используется что бы найти id Партии по её номеру
    [Authorize(Roles = "Admin, PoliMen")]
    public class PartiiController : ApiController
    {
        diplomEntities2 db = new diplomEntities2();
        public string Get(string str)
        {
            try
            {
                Партии_отходов musorCods = db.Партии_отходов.Where(b => b.Номер_партии_отходов == str).First();
                return musorCods.Id_партии_отходов.ToString();
            }
            catch
            {
                return "Такой партии нет!";
            }
        }
    }
}
