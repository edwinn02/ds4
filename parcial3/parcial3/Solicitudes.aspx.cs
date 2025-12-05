using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace parcial3
{
    public partial class Solicitudes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarSolicitudes();
            }
        }

        private void CargarSolicitudes()
        {
            using (var db = new Parcial3DBEntities1())
            {
                var datos =
                    from s in db.SolicitudPasaporte
                    join sol in db.Solicitante on s.SolicitanteId equals sol.SolicitanteId
                    join est in db.EstadoSolicitud on s.EstadoSolicitudId equals est.EstadoSolicitudId
                    select new
                    {
                        s.SolicitudId,
                        Documento = sol.NumeroDocumento,
                        NombreCompleto = sol.Nombres + " " + sol.Apellidos,
                        s.FechaSolicitud,
                        Estado = est.Nombre
                    };

                gvSolicitudes.DataSource = datos.ToList();
                gvSolicitudes.DataBind();
            }
        }

        protected void gvSolicitudes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvSolicitudes.DataKeys[e.RowIndex].Value);

            using (var db = new Parcial3DBEntities1())
            {
                var solicitud = db.SolicitudPasaporte.Find(id);
                if (solicitud != null)
                {
                    db.SolicitudPasaporte.Remove(solicitud);
                    db.SaveChanges();
                }
            }

            e.Cancel = true;
            CargarSolicitudes();
        }

        protected void gvSolicitudes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int id = Convert.ToInt32(gvSolicitudes.DataKeys[index].Value);
                Response.Redirect("EditarSolicitud.aspx?id=" + id);
            }

            if (e.CommandName == "ActualizarEstado")
            {
                int solicitudId = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                DropDownList ddlEstado = (DropDownList)row.FindControl("ddlEstado");

                int nuevoEstado = Convert.ToInt32(ddlEstado.SelectedValue);

                using (var db = new Parcial3DBEntities1())
                {
                    var solicitud = db.SolicitudPasaporte.Find(solicitudId);
                    if (solicitud != null)
                    {
                        solicitud.EstadoSolicitudId = nuevoEstado;
                        db.SaveChanges();
                    }
                }

                CargarSolicitudes();
            }
        }
    }
}
