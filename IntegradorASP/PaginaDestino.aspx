<%@ Page Title="Transferencia - Destino" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaginaDestino.aspx.cs" Inherits="IntegradorASP.PaginaDestino" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="panel panel-primary">
       <div class="panel-heading">
            Transferencia de datos entre páginas. Página destino
       </div>
       <div class="panel-body">
           <div class="panel panel-info">
                <div class="panel-heading">Transferencia a través de campos ocultos (POST) y a través de parámetros en la URL (GET)</div>
                <div class="panel-body">
                    <asp:Label ID="lblNombreCompleto" runat="server" Text="Nombre completo: "></asp:Label>
                </div>
            </div>
       </div>
    </div>
</asp:Content>
