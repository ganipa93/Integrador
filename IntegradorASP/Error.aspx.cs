using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntegradorASP
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Error"] == null & Request.QueryString["ex"] == null)
                {
                    Exception ex = HttpContext.Current.Server.GetLastError();
                    this.lblError.Text = ex.Message;
                    Server.ClearError();
                }
                if (Session["Error"] != null)
                {
                    Exception ex = (Exception)Session["Error"];
                    Session["Error"] = null;
                    this.lblError.Text = ex.Message;
                    
                }
                if (Request.QueryString["ex"] != null)
                {
                    this.lblError.Text = Request.QueryString["ex"];
                }
                
            }
            catch (Exception)
            {
              Response.Redirect("~/default.aspx");
            }
        }
    }
}