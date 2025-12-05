<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Solicitudes.aspx.cs" Inherits="parcial3.Solicitudes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Solicitudes</title>
</head>
<body>
    <form id="form1" runat="server">

        <h2>Listado de Solicitudes</h2>

        <asp:Button ID="btnNueva" runat="server"
            Text="Registrar nueva solicitud"
            PostBackUrl="~/NuevaSolicitud.aspx" />

        <br /><br />

        <asp:GridView ID="gvSolicitudes" runat="server" AutoGenerateColumns="False"
            DataKeyNames="SolicitudId"
            OnRowCommand="gvSolicitudes_RowCommand"
            OnRowDeleting="gvSolicitudes_RowDeleting">

            <Columns>

                <asp:BoundField DataField="SolicitudId" HeaderText="ID" />
                <asp:BoundField DataField="Documento" HeaderText="Documento" />
                <asp:BoundField DataField="NombreCompleto" HeaderText="Solicitante" />
                <asp:BoundField DataField="FechaSolicitud" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" />

                <asp:ButtonField Text="Ver/Editar" CommandName="Editar" ButtonType="Button" />

                <asp:CommandField ShowDeleteButton="True" />

                <asp:TemplateField HeaderText="Nuevo Estado">
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlEstado" runat="server">
                            <asp:ListItem Text="Recibida" Value="1" />
                            <asp:ListItem Text="En revisión" Value="2" />
                            <asp:ListItem Text="Aprobada" Value="3" />
                            <asp:ListItem Text="Impresa" Value="4" />
                            <asp:ListItem Text="Entregada" Value="5" />
                        </asp:DropDownList>

                        <asp:Button ID="btnActualizarEstado" runat="server"
                            Text="Cambiar"
                            CommandName="ActualizarEstado"
                            CommandArgument='<%# Eval("SolicitudId") %>' />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>

    </form>
</body>
</html>
