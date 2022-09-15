<%@ Page Title="Ayuda" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ayuda.aspx.cs" Inherits="IntegradorASP.Ayuda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
  <div class="panel panel-primary">
        <div class="panel-heading">
            Ayuda
        </div>
       <div class="panel-body">
           <ul>
               <li>
                   <asp:HyperLink ID="HyperLinkEstado" runat="server" NavigateUrl="~/Estado.aspx">Mantenimiento del estado de la aplicación</asp:HyperLink>
               </li>
               <li>
                   <asp:HyperLink ID="HyperLinkTransferencia" runat="server" NavigateUrl="~/PaginaOrigen.aspx">Transferencia de datos entre páginas</asp:HyperLink>
               </li>
           </ul>
       </div>
    </div>
</asp:Content>
