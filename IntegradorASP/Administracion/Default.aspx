<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IntegradorASP.Administracion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Administración
                </div>
                <div class="panel-body text-center">
                    <br />
                    <div>
                        <asp:GridView ID="GridView" runat="server" CssClass="table table-hover" GridLines="None" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSourceProductos">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLinkModificar" runat="server" NavigateUrl='<%# "~/Administracion/Detalle.aspx?id=" + Eval("Id") + "&modo=modificar" %>'>Modificar</asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLinkEliminar" runat="server" NavigateUrl='<%# "~/Administracion/Detalle.aspx?id=" + Eval("Id") + "&modo=eliminar" %>'>Eliminar</asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="LabelId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                                <asp:BoundField DataField="verCategoria" HeaderText="Categoria" ReadOnly="True" SortExpression="verCategoria" />
                                <asp:BoundField DataField="verProveedor" HeaderText="Proveedor" ReadOnly="True" SortExpression="verProveedor" />
                                <asp:BoundField DataField="Precio" HeaderText="Precio" SortExpression="Precio" DataFormatString="{0:c}">
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="ObjectDataSourceProductos" runat="server" SelectMethod="Listar" TypeName="Negocio.admProductos"></asp:ObjectDataSource>
                    </div>
                </div>
                <div class="panel-footer">
                    <div class="text-right">
                        <asp:Button ID="btnNuevo" CssClass="btn btn-primary" runat="server" Text="Nuevo producto" OnClick="btnNuevo_Click" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
