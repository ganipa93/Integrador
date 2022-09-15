using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntegradorASP
{
    public partial class Detalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int Id = Convert.ToInt32(Request.QueryString["id"]);
                try
                {
                    Entidades.Producto Producto = new Negocio.admProductos().Listar(Id);
                    this.lblProducto.Text = Producto.Nombre;
                    this.Image.ImageUrl = "Imagenes/" + Producto.Id.ToString() + ".jpg";
                    this.lblDescripcion.Text = "Presentación: " + Producto.Presentacion;
                    this.lblPrecio.Text = "Precio: " + String.Format("{0:c}", Producto.Precio);
                }
                catch (Exception ex)
                {
                    Session["Error"] = ex;
                    Server.Transfer("~/Error.aspx?");
                }
            }
            else
            {
                Response.Redirect("/default.aspx");
            }
        }
    }
}