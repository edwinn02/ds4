using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using CalculadoraWeb.Models;
using Newtonsoft.Json;
using System.Text;

namespace CalculadoraWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly string apiUrl = "https://localhost:44334/api/Calculos";
        private static readonly HttpClient _httpClient = new HttpClient();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Calcular(double numero1, double numero2, string operacion)
        {
            try
            {
                // Validación de división por cero
                if (operacion == "/" && numero2 == 0)
                {
                    return Json(new { success = false, message = "No se puede dividir por cero" });
                }

                var calculo = new Calculo
                {
                    Numero1 = numero1,
                    Numero2 = numero2,
                    Operacion = operacion
                };

                var json = JsonConvert.SerializeObject(calculo);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var resultadoString = await response.Content.ReadAsStringAsync();

                    // CORRECCIÓN PRINCIPAL: Deserializar el JSON que viene de la API
                    var resultadoObj = JsonConvert.DeserializeObject<Calculo>(resultadoString);

                    // Retornar el objeto con la estructura correcta
                    return Json(new
                    {
                        success = true,
                        Resultado = resultadoObj.Resultado
                    });
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    return Json(new
                    {
                        success = false,
                        message = $"Error del servidor: {response.StatusCode}"
                    });
                }
            }
            catch (HttpRequestException ex)
            {
                return Json(new
                {
                    success = false,
                    message = "No se pudo conectar con la API. Verifica que esté corriendo."
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = $"Error: {ex.Message}"
                });
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _httpClient?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}