using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class dbProveedores : Conexion
    {
        public List<Proveedor> Listar()
        {
            List<Proveedor> Lista = new List<Proveedor>();
            SQL = "SELECT SupplierId, CompanyName FROM Suppliers ORDER BY CompanyName";
            objComando.CommandText = SQL;
            try
            {
                objConexion.Open();
                SqlDataReader objReader = objComando.ExecuteReader();
                while (objReader.Read())
                {
                    Proveedor Item = new Proveedor();
                    Item.Id = (int)objReader["SupplierId"];
                    Item.Nombre = (string)objReader["CompanyName"];
                    Lista.Add(Item);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (objConexion.State == System.Data.ConnectionState.Open)
                {
                    objConexion.Close();
                }
            }
            return Lista;
        }
    }
}
