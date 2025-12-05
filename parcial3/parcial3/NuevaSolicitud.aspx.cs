using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace parcial3
{
    public partial class NuevaSolicitud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            using (var db = new Parcial3DBEntities1())
            {
                // 1. Crear un nuevo solicitante
                Solicitante sol = new Solicitante
                {
                    NumeroDocumento = txtDocumento.Text,
                    Nombres = txtNombres.Text,
                    Apellidos = txtApellidos.Text
                };

                db.Solicitante.Add(sol);
                db.SaveChanges();

                // 2. Crear solicitud asociada
                SolicitudPasaporte solicitud = new SolicitudPasaporte
                {
                    SolicitanteId = sol.SolicitanteId,
                    FechaSolicitud = DateTime.Now,
                    TipoSolicitud = ddlTipoSolicitud.SelectedValue,
                    EstadoSolicitudId = 1, // Asumimos que 1 = "Recibida"
                    Observaciones = txtObservaciones.Text
                };

                db.SolicitudPasaporte.Add(solicitud);
                db.SaveChanges();
            }

            Response.Redirect("Solicitudes.aspx");
        }
    }
}
