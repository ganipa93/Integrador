using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntegradorASP
{
    public partial class PaginaOrigen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PaginaDestino.aspx?nombre=" + this.txtNombre.Text + "&apellido=" + this.txtApellido.Text);
        }
    }
}