<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="IntegradorASP.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h4><asp:Label ID="lblProducto" runat="server" Text=""></asp:Label></h4>
        </div>
        <div class="panel-body">
            <br />
            <div class="row">
                <div class="col-md-3">
                    <asp:Image ID="Image" runat="server" />
                </div>
                <div class="col-md-9">
                    <h3><asp:Label ID="lblDescripcion" runat="server" CssClass="label label-info" Text=""></asp:Label></h3>
                    <br />
                    <h3><asp:Label ID="lblPrecio" runat="server" CssClass="label label-info" Text=""></asp:Label></h3>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
