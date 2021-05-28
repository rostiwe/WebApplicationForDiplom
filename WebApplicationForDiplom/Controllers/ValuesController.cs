using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationForDiplom.Models;

namespace WebApplicationForDiplom.Controllers
{
    [Authorize(Roles = "Admin, PoliMen, ")]
    public class ValuesController : ApiController
    {
        // GET api/values
        //Создание_базы_данныхEntities db = new Создание_базы_данныхEntities();
        diplomEntities db = new diplomEntities();
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(string str)
        {
            try
            {
                КодыИдентификацииОтходов musorCods = db.КодыИдентификацииОтходов.Where(b => b.Код == str).First();
                return musorCods.IdКода.ToString();
            }
            catch
            {
                return "Такого кода нет";
            }         
            //return db.КодыИдентификацииОтходов.Where(b => b.Код == str).Any().ToString();
            //return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
