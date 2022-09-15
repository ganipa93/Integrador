<%@ Page Title="Estado" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Estado.aspx.cs" Inherits="IntegradorASP.Estado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-md-8">
                            Ejemplo de mantenimiento del estado
                        </div>
                        <div class="col-md-4 text-right">
                            <asp:UpdateProgress ID="UpdateProgress" runat="server">
                                <ProgressTemplate>
                                    <div>
                                        <asp:Image ID="Image" runat="server" ImageUrl="~/espera.gif" ImageAlign="Right" Height="20" />
                                    </div>
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </div>
                    </div>
                </div>
                <div class="panel-body">
                    <div class="panel panel-info">
                        <div class="panel-heading">Postback</div>
                        <div class="panel-body">
                            <asp:Label ID="lblPostback" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="panel panel-info">
                        <div class="panel-heading">Web.config</div>
                        <div class="panel-body">
                            <asp:Label ID="lblWebConfig" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="panel panel-info">
                        <div class="panel-heading">Cookies</div>
                        <div class="panel-body">
                            <asp:Label ID="lblCookies" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="panel-footer">
                            <asp:Button ID="btnCrearCookieSesion" runat="server" CssClass="btn btn-default" Text="Crear cookie de sesión" OnClick="btnCrearCookieSesion_Click" />
                            <asp:Button ID="btnCrearCookie" runat="server" CssClass="btn btn-default" Text="Crear cookies persistentes" OnClick="btnCrearCookie_Click" />
                            <asp:Button ID="btnBorrarCookie" runat="server" CssClass="btn btn-default" Text="Borrar cookies persistentes" OnClick="btnBorrarCookie_Click" />
                            <asp:Button ID="btnPostBack" runat="server" CssClass="btn btn-default" Text="PostBack" />
                            <asp:Button ID="ButtonRefresh" runat="server" CssClass="btn btn-default" OnClick="ButtonRefresh_Click" Text="Refresh con postback" />
                        </div>
                    </div>
                    <div class="panel panel-info">
                        <div class="panel-heading">ViewState</div>
                        <div class="panel-body">
                            <asp:Label ID="lblViewState" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="panel-footer">
                            <asp:Button ID="btnViewState" runat="server" CssClass="btn btn-default" Text="Guardar ViewState" OnClick="btnViewState_Click" />
                        </div>
                    </div>
                    <div class="panel panel-info">
                        <div class="panel-heading">Variables de sesión y aplicación</div>
                        <div class="panel-body">
                            <asp:Label ID="lblSesion" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lblAplicacion" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="panel-footer">
                            <asp:Button ID="btnVariableSesion" runat="server" CssClass="btn btn-default" Text="Crear variable de sesión" OnClick="btnVariableSesion_Click" />
                            <asp:Button ID="btnAplicacion" runat="server" CssClass="btn btn-default" Text="Crear variable de aplicación" OnClick="btnAplicacion_Click" />
                        </div>
                    </div>
                    <div class="panel panel-info">
                        <div class="panel-heading">Ejemplo de utilización de la clase Global.asax</div>
                        <div class="panel-body">
                            <asp:Label ID="lblUsuariosOnline" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:Timer ID="Timer1" runat="server" Interval="5000"></asp:Timer>
</asp:Content>
