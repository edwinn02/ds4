using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using Laboratorio203.Models;

namespace Laboratorio203.Controllers
{
    public class LaptopsController : Controller
    {
        private readonly string _conn = ConfigurationManager.ConnectionStrings["ProductosDb"].ConnectionString;

        // GET: Laptops
        public ActionResult Index(int? buscarId)
        {
            
            var lista = new List<Laptop>();
            using (var con = new SqlConnection(_conn))
            {
                string sql = buscarId.HasValue
                    ? "SELECT ID, NOMBRE, PRECIO, STOCK FROM LAPTOPS WHERE ID=@ID"
                    : "SELECT ID, NOMBRE, PRECIO, STOCK FROM LAPTOPS";

                using (var cmd = new SqlCommand(sql, con))
                {
                    if (buscarId.HasValue)
                        cmd.Parameters.AddWithValue("@ID", buscarId.Value);

                    con.Open();
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new Laptop
                            {
                                Id = Convert.ToInt32(rd["ID"]),
                                Nombre = rd["NOMBRE"].ToString(),
                                Precio = Convert.ToDecimal(rd["PRECIO"]),
                                Stock = Convert.ToInt32(rd["STOCK"])
                            });
                        }
                    }
                }
            }

            if (buscarId.HasValue && lista.Count == 0)
            {
                TempData["Mensaje"] = "Ningún registro encontrado con el Id ingresado.";
            }

            return View(lista);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Laptop model)
        {
            if (!ModelState.IsValid) return View(model);

            using (var con = new SqlConnection(_conn))
            using (var cmd = new SqlCommand(
                "INSERT INTO LAPTOPS (NOMBRE, PRECIO, STOCK) VALUES (@NOMBRE, @PRECIO, @STOCK)", con))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@NOMBRE", model.Nombre ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@PRECIO", model.Precio);
                cmd.Parameters.AddWithValue("@STOCK", model.Stock);

                con.Open();
                var i = cmd.ExecuteNonQuery();
                TempData["Mensaje"] = i > 0 ? "Registro ingresado correctamente!" : "No se insertó el registro.";
            }
            return RedirectToAction("Index");
        }

        
        public ActionResult Edit(int id)
        {
            var item = ObtenerPorId(id);
            if (item == null)
            {
                TempData["Mensaje"] = "Ningún registro encontrado con el Id ingresado.";
                return RedirectToAction("Index");
            }
            return View(item);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Laptop model)
        {
            if (!ModelState.IsValid) return View(model);

            using (var con = new SqlConnection(_conn))
            using (var cmd = new SqlCommand(
                "UPDATE LAPTOPS SET NOMBRE=@NOMBRE, PRECIO=@PRECIO, STOCK=@STOCK WHERE ID=@ID", con))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@NOMBRE", model.Nombre ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@PRECIO", model.Precio);
                cmd.Parameters.AddWithValue("@STOCK", model.Stock);
                cmd.Parameters.AddWithValue("@ID", model.Id);

                con.Open();
                var i = cmd.ExecuteNonQuery();
                TempData["Mensaje"] = i > 0 ? "Registro actualizado correctamente!" : "No se actualizó el registro.";
            }
            return RedirectToAction("Index");
        }

        
        public ActionResult Delete(int id)
        {
            var item = ObtenerPorId(id);
            if (item == null)
            {
                TempData["Mensaje"] = "Ningún registro encontrado con el Id ingresado.";
                return RedirectToAction("Index");
            }
            return View(item);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var con = new SqlConnection(_conn))
            using (var cmd = new SqlCommand("DELETE FROM LAPTOPS WHERE ID=@ID", con))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                con.Open();
                var i = cmd.ExecuteNonQuery();
                TempData["Mensaje"] = i > 0 ? "Registro eliminado correctamente!" : "No se eliminó el registro.";
            }
            return RedirectToAction("Index");
        }

        
        public ActionResult Details(int id)
        {
            var item = ObtenerPorId(id);
            if (item == null)
            {
                TempData["Mensaje"] = "Ningún registro encontrado con el Id ingresado.";
                return RedirectToAction("Index");
            }
            return View(item);
        }

        
        private Laptop ObtenerPorId(int id)
        {
            using (var con = new SqlConnection(_conn))
            using (var cmd = new SqlCommand("SELECT ID, NOMBRE, PRECIO, STOCK FROM LAPTOPS WHERE ID=@ID", con))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                con.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        return new Laptop
                        {
                            Id = Convert.ToInt32(rd["ID"]),
                            Nombre = rd["NOMBRE"].ToString(),
                            Precio = Convert.ToDecimal(rd["PRECIO"]),
                            Stock = Convert.ToInt32(rd["STOCK"])
                        };
                    }
                }
            }
            return null;
        }
    }
}