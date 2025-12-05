<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NuevaSolicitud.aspx.cs" Inherits="parcial3.NuevaSolicitud" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Nueva Solicitud</title>
</head>
<body>
    <form id="form1" runat="server">

        <h2>Nueva Solicitud</h2>

        <label>Documento:</label><br />
        <asp:TextBox ID="txtDocumento" runat="server"></asp:TextBox><br /><br />

        <label>Nombres:</label><br />
        <asp:TextBox ID="txtNombres" runat="server"></asp:TextBox><br /><br />

        <label>Apellidos:</label><br />
        <asp:TextBox ID="txtApellidos" runat="server"></asp:TextBox><br /><br />

        <label>Tipo de solicitud:</label><br />
        <asp:DropDownList ID="ddlTipoSolicitud" runat="server">
            <asp:ListItem Text="Nueva" Value="Nueva" />
            <asp:ListItem Text="Renovación" Value="Renovacion" />
        </asp:DropDownList><br /><br />

        <label>Observaciones:</label><br />
        <asp:TextBox ID="txtObservaciones" runat="server" TextMode="MultiLine"></asp:TextBox><br /><br />

        <asp:Button ID="btnGuardar" Text="Guardar" runat="server" OnClick="btnGuardar_Click" />
        <br /><br />

        <asp:HyperLink NavigateUrl="Solicitudes.aspx" Text="Volver al listado" runat="server"></asp:HyperLink>

    </form>
</body>
</html>
