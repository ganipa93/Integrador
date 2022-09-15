using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntegradorASP
{
    public partial class PaginaDestino : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["nombre"] == null & Request.QueryString["apellido"] == null)
            {
                if (PreviousPage != null)
                {
                    TextBox txtNombre = null;
                    TextBox txtApellido = null;
                    if (PreviousPage.Master.FindControl("ContentPlaceHolder").FindControl("txtNombre") != null)
                    {
                        txtNombre = (TextBox)PreviousPage.Master.FindControl("ContentPlaceHolder").FindControl("txtNombre");
                    }
                    if (PreviousPage.Master.FindControl("ContentPlaceHolder").FindControl("txtApellido") != null)
                    {
                        txtApellido = (TextBox)PreviousPage.Master.FindControl("ContentPlaceHolder").FindControl("txtApellido");
                    }
                    if (txtNombre != null & txtApellido != null)
                    {
                        this.lblNombreCompleto.Text = this.lblNombreCompleto.Text + txtNombre.Text + " " + txtApellido.Text;
                    }
                }
            }
            else
            {
                this.lblNombreCompleto.Text = this.lblNombreCompleto.Text + Request.QueryString["nombre"] + " " + Request.QueryString["apellido"];
            }
        }
    }
}