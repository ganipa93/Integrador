<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IntegradorASP.Default" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ContentBody" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h4>Catálogo de productos</h4>
                    <h5>Seleccione una categoria:</h5>
                    <asp:DropDownList ID="DropDownList" runat="server" DataSourceID="ObjectDataSourceCategorias" DataTextField="Nombre" DataValueField="Id" AutoPostBack="True" CssClass="form-control"></asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectDataSourceCategorias" runat="server" SelectMethod="Listar" TypeName="Negocio.admCategorias"></asp:ObjectDataSource>
                </div>
                <div class="panel-body text-center">
                    <br />
                    <asp:ListView ID="ListView" runat="server" DataSourceID="ObjectDataSourceProductos" GroupItemCount="4">
                        <EmptyDataTemplate>
                            <table runat="server">
                                <tr>
                                    <td>No hay productos para esta categoría.</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <EmptyItemTemplate>
                            <td runat="server" />
                        </EmptyItemTemplate>
                        <GroupTemplate>
                            <tr id="itemPlaceholderContainer" runat="server">
                                <td id="itemPlaceholder" runat="server"></td>
                            </tr>
                        </GroupTemplate>
                        <ItemTemplate>
                            <td runat="server">
                                <table style="border-collapse: separate; border-spacing: 10px; margin-top: 0">
                                    <tr>
                                        <td rowspan="3">
                                            <asp:Image ID="Image" runat="server" ImageUrl='<%# "~/Imagenes/Thumbnails/tn" + Eval("Id") + "_100x100.jpg"  %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="NombreLabel" runat="server" Text='<%# Eval("Nombre") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="PrecioLabel" runat="server" Text='<%# String.Format("{0:c}", Eval("Precio")) %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:HyperLink ID="HyperLink" runat="server" NavigateUrl='<%# "~/Detalle.aspx?id=" + Eval("Id") %>'>+ Información</asp:HyperLink>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </ItemTemplate>
                        <LayoutTemplate>
                            <center>
                        <table runat="server">
                            <tr runat="server">
                                <td runat="server">
                                    <table id="groupPlaceholderContainer" runat="server" border="0" style="">
                                        <tr id="groupPlaceholder" runat="server">
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr runat="server">
                                <td runat="server">
                                    <div class="panel-footer">
                                        <div class="text-center">
                                            <asp:DataPager ID="DataPager1" runat="server" PageSize="12">
                                                <Fields>
                                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                                                </Fields>
                                            </asp:DataPager>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </center>
                        </LayoutTemplate>
                    </asp:ListView>
                    <asp:ObjectDataSource ID="ObjectDataSourceProductos" runat="server" SelectMethod="ListarPorCategoria" TypeName="Negocio.admProductos">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="DropDownList" Name="Id_Categoria" PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
