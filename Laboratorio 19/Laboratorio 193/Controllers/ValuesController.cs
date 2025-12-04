using Laboratorio193.Services;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Laboratorio19_3.Controllers
{
    public class ValuesController : Controller
    {
        
        private const string ApiBase = "https://localhost:44387/";

        
        public async Task<ActionResult> Detail(int id = 2)
        {
            var client = new ApiClient(ApiBase);
            var json = await client.GetAsync($"api/values/{id}");
            ViewBag.RawJson = json;
            ViewBag.Id = id;
            return View();
        }
    }
}