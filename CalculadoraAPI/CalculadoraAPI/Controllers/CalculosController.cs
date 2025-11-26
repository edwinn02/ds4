using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Http;
using CalculadoraAPI.Models;
using CalculadoraAPI.Data;

namespace CalculadoraAPI.Controllers
{
    public class CalculosController : ApiController
    {
        
        [HttpGet]
        [Route("api/calculos")]
        public IHttpActionResult GetTodosLosCalculos()
        {
            return Ok(GetCalculos("SELECT * FROM Calculos ORDER BY FechaCalculo DESC"));
        }

        
        [HttpGet]
        [Route("api/calculos/sumas")]
        public IHttpActionResult GetSumas()
        {
            return Ok(GetCalculos("SELECT * FROM Calculos WHERE Operacion = '+' ORDER BY FechaCalculo DESC"));
        }

        
        [HttpGet]
        [Route("api/calculos/restas")]
        public IHttpActionResult GetRestas()
        {
            return Ok(GetCalculos("SELECT * FROM Calculos WHERE Operacion = '-' ORDER BY FechaCalculo DESC"));
        }

     
        [HttpGet]
        [Route("api/calculos/multiplicaciones")]
        public IHttpActionResult GetMultiplicaciones()
        {
            return Ok(GetCalculos("SELECT * FROM Calculos WHERE Operacion = '*' ORDER BY FechaCalculo DESC"));
        }

      
        [HttpGet]
        [Route("api/calculos/divisiones")]
        public IHttpActionResult GetDivisiones()
        {
            return Ok(GetCalculos("SELECT * FROM Calculos WHERE Operacion = '/' ORDER BY FechaCalculo DESC"));
        }

        [HttpGet]
        [Route("api/calculos/potencias")]
        public IHttpActionResult GetPotencias()
        {
            return Ok(GetCalculos("SELECT * FROM Calculos WHERE Operacion = '^' ORDER BY FechaCalculo DESC"));
        }

       
        [HttpPost]
        [Route("api/calculos")]
        public IHttpActionResult PostCalculo(Calculo calculo)
        {
            try
            {
                // Validación de división por cero
                if (calculo.Operacion == "/" && calculo.Numero2 == 0)
                {
                    return BadRequest("No se puede dividir por cero");
                }

                // Calcular resultado según operación
                switch (calculo.Operacion)
                {
                    case "+": calculo.Resultado = calculo.Numero1 + calculo.Numero2; break;
                    case "-": calculo.Resultado = calculo.Numero1 - calculo.Numero2; break;
                    case "*": calculo.Resultado = calculo.Numero1 * calculo.Numero2; break;
                    case "/": calculo.Resultado = calculo.Numero1 / calculo.Numero2; break;
                    case "^": calculo.Resultado = Math.Pow(calculo.Numero1, calculo.Numero2); break;
                    default: return BadRequest("Operación inválida");
                }

                calculo.FechaCalculo = DateTime.Now;

                // Guardar en la base de datos
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"INSERT INTO Calculos (Numero1, Numero2, Operacion, Resultado, FechaCalculo)
                                     VALUES (@Numero1, @Numero2, @Operacion, @Resultado, @FechaCalculo)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Numero1", calculo.Numero1);
                        cmd.Parameters.AddWithValue("@Numero2", calculo.Numero2);
                        cmd.Parameters.AddWithValue("@Operacion", calculo.Operacion);
                        cmd.Parameters.AddWithValue("@Resultado", calculo.Resultado);
                        cmd.Parameters.AddWithValue("@FechaCalculo", calculo.FechaCalculo);

                        cmd.ExecuteNonQuery();
                    }
                }

                return Ok(calculo);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // Método auxiliar para evitar repetir código
        private List<Calculo> GetCalculos(string query)
        {
            var calculos = new List<Calculo>();
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        calculos.Add(new Calculo
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Numero1 = Convert.ToDouble(reader["Numero1"]),
                            Numero2 = Convert.ToDouble(reader["Numero2"]),
                            Operacion = reader["Operacion"].ToString(),
                            Resultado = Convert.ToDouble(reader["Resultado"]),
                            FechaCalculo = Convert.ToDateTime(reader["FechaCalculo"])
                        });
                    }
                }
            }
            return calculos;
        }
    }
}