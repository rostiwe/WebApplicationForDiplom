using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationForDiplom.Models;

namespace WebApplicationForDiplom.Controllers
{
    [Authorize(Roles = "Admin, PoliMen, SborMen")]
    public class PartiiController : ApiController
    {
        diplomEntities1 db = new diplomEntities1();
        public string Get(string str)
        {
            try
            {
                ПартииОтходов musorCods = db.ПартииОтходов.Where(b => b.НомерПартии == str).First();
                return musorCods.IdПартииОтходов.ToString();
            }
            catch
            {
                return "Такого кода нет";
            }
        }
    }
}
