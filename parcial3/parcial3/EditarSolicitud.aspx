<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditarSolicitud.aspx.cs" Inherits="parcial3.EditarSolicitud" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Editar Solicitud</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Editar Solicitud</h2>

        <asp:Label ID="lblId" runat="server" Text=""></asp:Label>
        <br /><br />

        Documento:<br />
        <asp:TextBox ID="txtDocumento" runat="server"></asp:TextBox><br /><br />

        Nombres:<br />
        <asp:TextBox ID="txtNombres" runat="server"></asp:TextBox><br /><br />

        Apellidos:<br />
        <asp:TextBox ID="txtApellidos" runat="server"></asp:TextBox><br /><br />

        Tipo de solicitud:<br />
        <asp:DropDownList ID="ddlTipoSolicitud" runat="server">
            <asp:ListItem Text="Nueva" Value="Nueva" />
            <asp:ListItem Text="Renovacion" Value="Renovacion" />
        </asp:DropDownList><br /><br />

        Estado:<br />
        <asp:DropDownList ID="ddlEstado" runat="server"></asp:DropDownList><br /><br />

        Observaciones:<br />
        <asp:TextBox ID="txtObservaciones" runat="server" TextMode="MultiLine"></asp:TextBox><br /><br />

        <asp:Button ID="btnGuardar" runat="server" Text="Guardar cambios" OnClick="btnGuardar_Click" />
        <br /><br />

        <asp:HyperLink ID="lnkVolver" runat="server" NavigateUrl="Solicitudes.aspx" Text="Volver al listado"></asp:HyperLink>
    </form>
</body>
</html>
