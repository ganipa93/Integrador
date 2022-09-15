using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Datos
{
    public class Conexion
    {
        protected SqlConnection objConexion = new SqlConnection();
        protected SqlCommand objComando = new SqlCommand();
        protected string SQL;
        public Conexion()
        {
            try
            {
                this.objConexion.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString;
                this.objComando.Connection = this.objConexion;
                this.objComando.CommandType = System.Data.CommandType.Text;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
