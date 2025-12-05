using System;
using System.Linq;

namespace parcial3
{
    public partial class EditarSolicitud : System.Web.UI.Page
    {
        private int SolicitudId
        {
            get
            {
                int id = 0;
                int.TryParse(Request.QueryString["id"], out id);
                return id;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEstados();
                CargarDatos();
            }
        }

        private void CargarEstados()
        {
            using (var db = new Parcial3DBEntities1())
            {
                ddlEstado.DataSource = db.EstadoSolicitud.ToList();
                ddlEstado.DataTextField = "Nombre";
                ddlEstado.DataValueField = "EstadoSolicitudId";
                ddlEstado.DataBind();
            }
        }

        private void CargarDatos()
        {
            using (var db = new Parcial3DBEntities1())
            {
                var solicitud = db.SolicitudPasaporte.FirstOrDefault(s => s.SolicitudId == SolicitudId);
                if (solicitud == null) return;

                lblId.Text = "Solicitud #" + solicitud.SolicitudId;

                var solicitante = db.Solicitante.FirstOrDefault(x => x.SolicitanteId == solicitud.SolicitanteId);

                txtDocumento.Text = solicitante.NumeroDocumento;
                txtNombres.Text = solicitante.Nombres;
                txtApellidos.Text = solicitante.Apellidos;

                ddlTipoSolicitud.SelectedValue = solicitud.TipoSolicitud;
                ddlEstado.SelectedValue = solicitud.EstadoSolicitudId.ToString();
                txtObservaciones.Text = solicitud.Observaciones;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            using (var db = new Parcial3DBEntities1())
            {
                var solicitud = db.SolicitudPasaporte.FirstOrDefault(s => s.SolicitudId == SolicitudId);
                if (solicitud == null) return;

                var solicitante = db.Solicitante.FirstOrDefault(x => x.SolicitanteId == solicitud.SolicitanteId);

                solicitante.NumeroDocumento = txtDocumento.Text;
                solicitante.Nombres = txtNombres.Text;
                solicitante.Apellidos = txtApellidos.Text;

                solicitud.TipoSolicitud = ddlTipoSolicitud.SelectedValue;
                solicitud.EstadoSolicitudId = int.Parse(ddlEstado.SelectedValue);
                solicitud.Observaciones = txtObservaciones.Text;

                db.SaveChanges();
            }

            Response.Redirect("Solicitudes.aspx");
        }
    }
}
