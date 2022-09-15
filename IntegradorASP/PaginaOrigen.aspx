<%@ Page Title="Transferencia - Origen" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaginaOrigen.aspx.cs" Inherits="IntegradorASP.PaginaOrigen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="panel panel-primary">
       <div class="panel-heading">
            Transferencia de datos entre páginas. Página origen
       </div>
       <div class="panel-body">
           <div class="panel panel-info">
                <div class="panel-heading">Transferencia a través de campos ocultos (POST) y a través de parámetros en la URL (GET)</div>
                <div class="panel-body">
                   <div class="form-group">
                        <label for="txtNombre">Nombre</label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Width="300px"></asp:TextBox>
                   </div>
                    <div class="form-group">
                        <label for="txtApellido">Apellido</label>
                        <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" Width="300px"></asp:TextBox>
                   </div>
                </div>
               <div class="panel-footer">
                   <asp:Button ID="btnPost" runat="server" CssClass="btn btn-default" Text="POST" PostBackUrl="~/PaginaDestino.aspx" />
                   <asp:Button ID="btnGet" runat="server" CssClass="btn btn-default" Text="GET" OnClick="btnGet_Click" />
               </div>
            </div>
       </div>
    </div>
</asp:Content>
