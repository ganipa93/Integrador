<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="IntegradorASP.Formulario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <asp:Label ID="lblTitulo" runat="server" Text="Titulo"></asp:Label>
        </div>
        <div class="panel-body">
            <br />
            <div class="form-horizontal">
                <div class="form-group">
                    <label for="txtNombre" class="col-sm-2 control-label">Nombre</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" MaxLength="40"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label for="cmbCategoria" class="col-sm-2 control-label">Categoria</label>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="cmbCategoria" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <label for="cmbProveedor" class="col-sm-2 control-label">Proveedor</label>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="cmbProveedor" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtPresentacion" class="col-sm-2 control-label">Presentación</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtPresentacion" runat="server" CssClass="form-control" MaxLength="20"></asp:TextBox>
                    </div>
                </div>
                 <div class="form-group">
                 <label for="txtUnidadesStock" class="col-sm-2 control-label">Unidades en stock</label>
                    <div class="col-sm-2">
                        <asp:TextBox ID="txtUnidadesStock" runat="server" CssClass="form-control text-right" TextMode="Number"></asp:TextBox>
                    </div>
                     <label for="txtUnidadesPedidas" class="col-sm-2 control-label">Unidades pedidas</label>
                    <div class="col-sm-2">
                        <asp:TextBox ID="txtUnidadesPedidas" runat="server" CssClass="form-control text-right" TextMode="Number"></asp:TextBox>
                    </div>
                    <label for="txtNivelReposicion" class="col-sm-2 control-label">Nivel de reposición</label>
                    <div class="col-sm-2">
                        <asp:TextBox ID="txtNivelReposicion" runat="server" CssClass="form-control text-right" TextMode="Number"></asp:TextBox>
                    </div>
                 </div>
                <div class="form-group">
                    <label for="txtPrecio" class="col-sm-2 control-label">Precio</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control text-right" TextMode="Number"></asp:TextBox>
                    </div>
                    <label for="chkDescontinuado" class="col-sm-2 control-label">Descontinuado</label>
                    <div class="col-sm-4">
                        <asp:CheckBox ID="chkDescontinuado" runat="server" CssClass="form-control" />
                    </div>
                </div>
            </div >
            <br />
            <div class="text-danger">
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorNombre" runat="server" ErrorMessage="En nombre del producto es obligatorio." ControlToValidate="txtNombre" Display="None"></asp:RequiredFieldValidator>
                <asp:ValidationSummary ID="ValidationSummary" runat="server" />
            </div>
        </div>
        <div class="panel-footer">
            <div class="text-right">
                <asp:Button ID="btnAceptar" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="btnAceptar_Click" />
            </div>
        </div>
    </div>
</asp:Content>
