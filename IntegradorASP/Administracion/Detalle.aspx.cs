using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntegradorASP
{
    public partial class Formulario : System.Web.UI.Page
    {
        private Entidades.Producto Producto = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["modo"] != null)
            {
                string Modo = Request.QueryString["modo"];
                switch(Modo)
                {
                    case "nuevo":
                        break;
                    case "modificar":
                        break;
                    case "eliminar":
                        break;
                    default:
                        Response.Redirect("~/administracion/default.aspx"); 
                    break;
                }
                if (Request.QueryString["id"] != null & Request.QueryString["id"] != null & (Modo == "modificar" | Modo == "eliminar"))
                {

                    int Id = Convert.ToInt32(Request.QueryString["id"]);
                    if (!IsPostBack & Modo == "modificar")
                    {
                        this.CargarDropDownLists();

                        try
                        {
                            Producto = new Negocio.admProductos().Listar(Id);
                        }
                        catch (Exception ex)
                        {
                            Session["Error"] = ex;
                            Server.Transfer("~/Error.aspx?");
                        }
                        this.lblTitulo.Text = Producto.Nombre;
                        this.txtNombre.Text = Producto.Nombre;
                        this.cmbCategoria.SelectedValue = Producto.Categoria.Id.ToString();
                        this.cmbProveedor.SelectedValue = Producto.Proveedor.Id.ToString();
                        this.txtPresentacion.Text = Producto.Presentacion;
                        this.txtUnidadesPedidas.Text = Producto.Stock.UnidadesPedidas.ToString();
                        this.txtUnidadesStock.Text = Producto.Stock.UnidadesStock.ToString();
                        this.txtNivelReposicion.Text = Producto.Stock.NivelReposicion.ToString();
                        this.txtPrecio.Text = Producto.Precio.ToString();
                        this.chkDescontinuado.Checked = Producto.Descontinuado;
                    }
                    else
                    {
                        if (!IsPostBack)
                        {
                            new Negocio.admProductos().Eliminar(Id);
                            Response.Redirect("~/administracion/default.aspx");  
                        }
                    }
                }
                else
                {
                    if(Modo =="nuevo")
                    {
                        this.CargarDropDownLists();
                    }
                    else
                    {
                        
                        Response.Redirect("~/administracion/default.aspx"); 
                    }
                }
            }
            else
            {
                Response.Redirect("~/administracion/default.aspx"); 
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            if (Producto == null) { Producto = new Entidades.Producto(); }

            if (Request.QueryString["id"] != null)
            {
                Producto.Id = Convert.ToInt32(Request.QueryString["id"]); 
            }

            try
            {
                Producto.Nombre = this.txtNombre.Text.Trim();
                Producto.Categoria.Id = Convert.ToInt32(this.cmbCategoria.SelectedValue);
                Producto.Proveedor.Id = Convert.ToInt32(this.cmbProveedor.SelectedValue);
                Producto.Presentacion = this.txtPresentacion.Text.Trim();
                if (this.txtUnidadesPedidas.Text.Trim().Length > 0)
                {
                    Producto.Stock.UnidadesPedidas = Convert.ToInt32(this.txtUnidadesPedidas.Text.Trim());
                }
                else
                {
                    Producto.Stock.UnidadesPedidas = null;
                }
                if (this.txtUnidadesStock.Text.Trim().Length > 0)
                {
                    Producto.Stock.UnidadesStock = Convert.ToInt32(this.txtUnidadesStock.Text.Trim());
                }
                else
                {
                    Producto.Stock.UnidadesStock = null;
                }
                if (this.txtNivelReposicion.Text.Trim().Length > 0)
                {
                    Producto.Stock.NivelReposicion = Convert.ToInt32(this.txtNivelReposicion.Text.Trim());
                }
                else
                {
                    Producto.Stock.NivelReposicion = null;
                }
                if (this.txtPrecio.Text.Trim().Length > 0)
                {
                    Producto.Precio = Convert.ToDecimal(this.txtPrecio.Text.Trim());
                }
                else
                {
                    Producto.Precio = null;
                }
                Producto.Descontinuado = this.chkDescontinuado.Checked;

                if (Producto.Id != 0)
                {
                    new Negocio.admProductos().Actualizar(Producto);
                    Response.Redirect("~/administracion/default.aspx");
                }
                else
                {
                    new Negocio.admProductos().Agregar(Producto);
                    Response.Redirect("~/administracion/default.aspx");
                }
            }
            catch (Exception ex)
            {
                Session["Error"] = ex;
                Server.Transfer("~/Error.aspx?");
            }
        }

        private void CargarDropDownLists()
        {
            try
            {
                this.cmbCategoria.DataValueField = "Id";
                this.cmbCategoria.DataTextField = "Nombre";
                this.cmbCategoria.DataSource = new Negocio.admCategorias().Listar();
                this.cmbCategoria.DataBind();

                this.cmbProveedor.DataValueField = "Id";
                this.cmbProveedor.DataTextField = "Nombre";
                this.cmbProveedor.DataSource = new Negocio.admProveedores().Listar();
                this.cmbProveedor.DataBind();
            }
            catch (Exception ex)
            {
                Session["Error"] = ex;
                Server.Transfer("~/Error.aspx?");
            }
        }
    }
}