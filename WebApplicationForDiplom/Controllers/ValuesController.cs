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
    public class ValuesController : ApiController
    {
        //Создание_базы_данныхEntities db = new Создание_базы_данныхEntities();
        diplomEntities2 db = new diplomEntities2();
        // GET api/values/5
        public string Get(string str)
        {
            try
            {
                // Ищем запись с кодом, по коду
                Коды_отходов musorCods = db.Коды_отходов.Where(b => b.Код == str).First();
                int i = musorCods.Количество;
                // Проверяем не превышино ли количетво записей
                IQueryable<Собранные_отходы_клиентов> Sobr = db.Собранные_отходы_клиентов.Where(b => b.Id_Кода == musorCods.Id_Кода);
                if (Sobr.Count() >= i)
                    return "Код найден, но максимальное число записей уже сделанно!";
                return musorCods.Id_Кода.ToString();
            }
            catch
            {
                return "Такого кода нет";
            }         
        }
    }
}
