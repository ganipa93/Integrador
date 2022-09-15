using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntegradorASP
{
   
    public partial class Estado : System.Web.UI.Page
    {
        private string Mensaje = string.Empty;
        private string ListaCookies = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            //Postback
            if (IsPostBack)
            {
                this.lblPostback.Text = "Es postback";
            }
            else
            {
                this.lblPostback.Text = "No es postback";
            }

            //Web.config
            lblWebConfig.Text = "Valor de la clave Empresa: " + System.Configuration.ConfigurationManager.AppSettings["Empresa"];

            //cookies
            if (Request.Cookies["Sesion"] != null)
            {
                Mensaje = Mensaje + "Valor de la cookie de sesión: " + Request.Cookies["Sesion"].Value + "<br>";
            }

            if (Request.Cookies["Persistente"] != null)
            {
                Mensaje = Mensaje + "Valor de la cookie persistente: " + Request.Cookies["Persistente"].Value + "<br>";
            }

            if (Request.Cookies["PersistenteMultivalor"] != null)
            {
                Mensaje = Mensaje + "Valor de la cookie persistente multivalor correspondiente a la fecha: " + Request.Cookies["PersistenteMultivalor"]["Fecha"] + "<br>";
                Mensaje = Mensaje + "Valor de la cookie persistente multivalor correspondiente a la hora: " + Request.Cookies["PersistenteMultivalor"]["Hora"] + "<br>";
            }
            this.lblCookies.Text = Mensaje;

            //View state
            if (ViewState["Persona"] != null)
            {
                Persona obj = (Persona)ViewState["Persona"];
                this.lblViewState.Text = obj.Nombre;
            }

            //Sesion
            if (Session["VariableSesion"] != null)
            {
                Persona obj = (Persona)Session["VariableSesion"];
                this.lblSesion.Text = obj.Nombre;
            }

            //Aplicacion
            if (Application["VariableAplicacion"] != null)
            {
                Persona obj = (Persona)Application["VariableAplicacion"];
                this.lblAplicacion.Text = obj.Nombre;
            }

            if (Application["UsuariosOnline"] != null)
            {
                this.lblUsuariosOnline.Text = "Usuarios online: " + Application["UsuariosOnline"].ToString();
            }
        }

        protected void btnBorrarCookie_Click(object sender, EventArgs e)
        {
            Response.Cookies["Persistente"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["PersistenteMultivalor"].Expires = DateTime.Now.AddDays(-1);
        }

        protected void btnCrearCookieSesion_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["Sesion"] == null)
            {
                Response.Cookies["Sesion"].Value = DateTime.Now.ToString();
            }
        }
        protected void btnCrearCookie_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["Persistente"] == null)
            {
                Response.Cookies["Persistente"].Value = DateTime.Now.ToString();
                Response.Cookies["Persistente"].Expires = DateTime.Now.AddYears(1);
            }

            if (Request.Cookies["PersistenteMultivalor"] == null)
            {
                Response.Cookies["PersistenteMultivalor"]["Fecha"] = DateTime.Now.Date.ToString();
                Response.Cookies["PersistenteMultivalor"]["Hora"] = DateTime.Now.Hour.ToString();
                Response.Cookies["PersistenteMultivalor"].Expires = DateTime.Now.AddYears(1);
            }

        }

        protected void btnViewState_Click(object sender, EventArgs e)
        {
            if (ViewState["Persona"] == null)
            {
                Persona obj = new Persona("Pepe");
                ViewState["Persona"] = obj;
            }
        }

        protected void ButtonRefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnVariableSesion_Click(object sender, EventArgs e)
        {
            Persona obj = new Persona("Pepe");
            Session["VariableSesion"] = obj;
        }

        protected void btnAplicacion_Click(object sender, EventArgs e)
        {
            Persona obj = new Persona("Maria");
            Application["VariableAplicacion"] = obj;
        }

        [Serializable]
        public class Persona
        {
            public Persona() { }
            public Persona(string paramNombre)
            {
                this.Nombre = paramNombre;
            }
            public string Nombre { get; set; }
        }

    }
}