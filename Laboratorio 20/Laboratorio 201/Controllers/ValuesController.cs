using System.Collections.Generic;
using System.Web.Mvc;

namespace Laboratorio201.Controllers
{
    public class ValuesController : Controller
    {
        // GET: /Values
        public ActionResult Index()
        {
            return View();
        }

        // POST: /Values/Table
        [HttpPost]
        public ActionResult Table(int numero)
        {
            var resultados = new List<string>();
            for (int i = 1; i <= 25; i++)
            {
                resultados.Add($"{numero} x {i} = {numero * i}");
            }
            ViewBag.Numero = numero;
            ViewBag.Resultados = resultados;
            return View();
        }
    }
}