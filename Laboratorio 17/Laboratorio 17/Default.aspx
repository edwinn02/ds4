<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Laboratorio_17._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div>
           <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="ProductID" DataSourceID="SqlDataSource1" AllowPaging="True" 
                AllowSorting="True">
            <Columns>
                <asp:BoundField DataField="ProductID" HeaderText="ProductID" ReadOnly="True" SortExpression="ProductID" />
                <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice" />
            </Columns>
          </asp:GridView>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="data source=Sara\SQLEXPRESS;initial catalog=northwind;persist security info=True;Integrated Security=SSPI;" 
                ProviderName="System.Data.SqlClient" 
                SelectCommand="SELECT ProductId, ProductName, UnitPrice From Products" 
                UpdateCommand="Update Products Set [ProductName]=@ProductName, [UnitPrice]=@UnitPrice Where [ProductId]=@ProductId">
            </asp:SqlDataSource>
        </div>
</asp:Content>
