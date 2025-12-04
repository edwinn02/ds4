using System.Web.Mvc;

namespace Laboratorio202.Controllers
{
    public class MatrixController : Controller
    {
        // GET: /Matrix
        public ActionResult Index()
        {
            return View();
        }

        // POST: /Matrix/Result
        [HttpPost]
        public ActionResult Result(int n)
        {
            if (n <= 0 || n > 200)
            {
                ViewBag.Error = "N debe ser mayor a 0 y razonable (ej. <= 200).";
                return View("Index");
            }

            int[,] matriz = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    // Diagonal inversa: posiciones (i, n-1-i)
                    matriz[i, j] = (j == (n - 1 - i)) ? 1 : 0;
                }
            }

            ViewBag.N = n;
            ViewBag.Matriz = matriz;
            return View();
        }
    }
}