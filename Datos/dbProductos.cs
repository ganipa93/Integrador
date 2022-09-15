using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
	public class dbProductos:Conexion
	{
		public Producto Listar(int Id)
		{
			SQL = "SELECT ProductId, ProductName, Products.SupplierId, CompanyName, Products.CategoryId, CategoryName, QuantityPerUnit, UnitPrice, ReorderLevel, UnitsInStock, UnitsOnOrder, Discontinued FROM Products ";
			SQL = SQL + "INNER JOIN Categories ON Products.CategoryId = Categories.CategoryId " ;
			SQL = SQL + "INNER JOIN Suppliers ON Products.SupplierId = Suppliers.SupplierId ";
			SQL = SQL + "WHERE ProductId=@Id ";
			objComando.CommandText = SQL;
			objComando.Parameters.AddWithValue("@Id", Id);
			Producto Item;
			try
			{
				objConexion.Open();
				SqlDataReader objReader = objComando.ExecuteReader();
				Item = new Producto();
				if (objReader.Read())
				{
					Item.Id = (int)objReader["ProductId"];
					Item.Nombre = (string)objReader["ProductName"];
					Item.Presentacion = (string)objReader["QuantityPerUnit"];
					Item.Proveedor = new Proveedor();
					Item.Proveedor.Id = (int)objReader["SupplierId"];
					Item.Proveedor.Nombre = objReader["CompanyName"].ToString();
					Item.Categoria = new Categoria();
					Item.Categoria.Id = (int)objReader["CategoryId"];
					Item.Categoria.Nombre = objReader["CategoryName"].ToString();
					Item.Precio = (decimal)objReader["UnitPrice"];
					Item.Stock = new Stock();

					if (objReader["ReorderLevel"] != DBNull.Value)
					{
						Item.Stock.NivelReposicion = Convert.ToInt32(objReader["ReorderLevel"]);
					}
					else
					{
						Item.Stock.NivelReposicion = null;
					}

					if (objReader["UnitsInStock"] != DBNull.Value)
					{
						Item.Stock.UnidadesStock = Convert.ToInt32(objReader["UnitsInStock"]);
					}
					else
					{
						Item.Stock.UnidadesStock = null;
					}

					if (objReader["UnitsOnOrder"] != DBNull.Value)
					{
						Item.Stock.UnidadesPedidas = Convert.ToInt32(objReader["UnitsOnOrder"]);
					}
					else
					{
						Item.Stock.UnidadesPedidas = null;
					}

					Item.Descontinuado = (bool)objReader["Discontinued"];
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
			return Item;
		}
		public List<verProducto> Listar()
		{
			List<verProducto> Lista = new List<verProducto>();
			SQL = "SELECT ProductId, ProductName, CategoryName, CompanyName, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued FROM Products ";
			SQL = SQL + "INNER JOIN Suppliers ON Products.SupplierId = Suppliers.SupplierId ";
			SQL = SQL + "INNER JOIN Categories ON Products.CategoryId = Categories.CategoryId ";
			SQL = SQL + " ORDER BY ProductName";
			objComando.CommandText = SQL;
			try
			{
				objConexion.Open();
				SqlDataReader objReader = objComando.ExecuteReader();
				while (objReader.Read())
				{
					verProducto Item = new verProducto();
					Item.Id = (int)objReader["ProductId"];
					Item.Nombre = (string)objReader["ProductName"];
					Item.Categoria = new Categoria();
					Item.Categoria.Nombre = (string)objReader["CategoryName"];
					Item.Proveedor = new Proveedor();
					Item.Proveedor.Nombre = (string)objReader["CompanyName"];
					Item.Presentacion = (string)objReader["QuantityPerUnit"];
					if (objReader["UnitPrice"] != DBNull.Value)
					{
						Item.Precio = (decimal)objReader["UnitPrice"];
					}
					else
					{
						Item.Precio = null;
					}
					Item.Stock = new Stock();
					if (objReader["ReorderLevel"] != DBNull.Value)
					{
						Item.Stock.NivelReposicion = Convert.ToInt32(objReader["ReorderLevel"]);
					}
					else
					{
						Item.Stock.NivelReposicion = null;
					}
					if (objReader["UnitsOnOrder"] != DBNull.Value)
					{
						Item.Stock.UnidadesPedidas = Convert.ToInt32(objReader["UnitsOnOrder"]);
					}
					else
					{
						Item.Stock.UnidadesPedidas = null;
					}
					if (objReader["UnitsInStock"] != DBNull.Value)
					{
						Item.Stock.UnidadesStock = Convert.ToInt32(objReader["UnitsInStock"]);
					}
					else
					{
						Item.Stock.UnidadesStock = null;
					}
					Item.Descontinuado = (bool)objReader["Discontinued"];
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
		public List<verProducto> ListarPorCategoria(Categoria Categoria)
		{
			List<verProducto> Lista = new List<verProducto>();
			SQL = "SELECT ProductId, ProductName, CategoryName, CompanyName, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued FROM Products ";
			SQL = SQL + "INNER JOIN Suppliers ON Products.SupplierId = Suppliers.SupplierId ";
			SQL = SQL + "INNER JOIN Categories ON Products.CategoryId = Categories.CategoryId ";
			if (Categoria.Id != 0)
			{
				SQL = SQL + "WHERE Products.CategoryId=@CategoryId ";
			}
			SQL = SQL + " ORDER BY ProductName";
			objComando.CommandText = SQL;
			objComando.Parameters.AddWithValue("@CategoryId", Categoria.Id);
			try
			{
				objConexion.Open();
				SqlDataReader objReader = objComando.ExecuteReader();
				while (objReader.Read())
				{
					verProducto Item = new verProducto();
					Item.Id = (int)objReader["ProductId"];
					Item.Nombre = (string)objReader["ProductName"];
					Item.Categoria = new Categoria();
					Item.Categoria.Nombre = (string)objReader["CategoryName"];
					Item.Proveedor = new Proveedor();
					Item.Proveedor.Nombre = (string)objReader["CompanyName"];
					Item.Presentacion = (string)objReader["QuantityPerUnit"];
					if (objReader["UnitPrice"] != DBNull.Value)
					{
						Item.Precio = (decimal)objReader["UnitPrice"];
					}
					else
					{
						Item.Precio = null;
					}
					Item.Stock = new Stock();
					if (objReader["ReorderLevel"] != DBNull.Value)
					{
						Item.Stock.NivelReposicion = Convert.ToInt32(objReader["ReorderLevel"]);
					}
					else
					{
						Item.Stock.NivelReposicion = null;
					}
					Item.Stock.UnidadesPedidas = Convert.ToInt32(objReader["UnitsOnOrder"]);
					Item.Stock.UnidadesStock = Convert.ToInt32(objReader["UnitsInStock"]);
					Item.Descontinuado = (bool)objReader["Discontinued"];
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
		public List<verProducto> ListarPorCategoria(int Id_Categoria)
		{
			List<verProducto> Lista = new List<verProducto>();
			SQL = "SELECT ProductId, ProductName, CategoryName, CompanyName, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued FROM Products ";
			SQL = SQL + "INNER JOIN Suppliers ON Products.SupplierId = Suppliers.SupplierId ";
			SQL = SQL + "INNER JOIN Categories ON Products.CategoryId = Categories.CategoryId ";
			if (Id_Categoria != 0)
			{
				SQL = SQL + "WHERE Products.CategoryId=@CategoryId ";
			}
			SQL = SQL + " ORDER BY ProductName";
			objComando.CommandText = SQL;
			objComando.Parameters.AddWithValue("@CategoryId", Id_Categoria);
			try
			{
				objConexion.Open();
				SqlDataReader objReader = objComando.ExecuteReader();
				while (objReader.Read())
				{
					verProducto Item = new verProducto();
					Item.Id = (int)objReader["ProductId"];
					Item.Nombre = (string)objReader["ProductName"];
					Item.Categoria = new Categoria();
					Item.Categoria.Nombre = (string)objReader["CategoryName"];
					Item.Proveedor = new Proveedor();
					Item.Proveedor.Nombre = (string)objReader["CompanyName"];
					Item.Presentacion = (string)objReader["QuantityPerUnit"];
					if (objReader["UnitPrice"] != DBNull.Value)
					{
						Item.Precio = (decimal)objReader["UnitPrice"];
					}
					else
					{
						Item.Precio = null;
					}
					Item.Stock = new Stock();
					if (objReader["ReorderLevel"] != DBNull.Value)
					{
						Item.Stock.NivelReposicion = Convert.ToInt32(objReader["ReorderLevel"]);
					}
					else
					{
						Item.Stock.NivelReposicion = null;
					}
					Item.Stock.UnidadesPedidas = Convert.ToInt32(objReader["UnitsOnOrder"]);
					Item.Stock.UnidadesStock = Convert.ToInt32(objReader["UnitsInStock"]);
					Item.Descontinuado = (bool)objReader["Discontinued"];
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
		public void Agregar(Producto Producto)
		{
			SQL = "INSERT INTO Products ";
			SQL = SQL + "(ProductName, SupplierId, CategoryId, QuantityPerUnit, UnitPrice, ReorderLevel, UnitsInStock, UnitsOnOrder, Discontinued) ";
			SQL = SQL + "VALUES ";
			SQL = SQL + "(@ProductName, @SupplierId, @CategoryId, @QuantityPerUnit, @UnitPrice, @ReorderLevel, @UnitsInStock, @UnitsOnOrder, @Discontinued)";
			objComando.Parameters.AddWithValue("@ProductName", Producto.Nombre);
			objComando.Parameters.AddWithValue("@SupplierId", Producto.Proveedor.Id);
			objComando.Parameters.AddWithValue("@CategoryId", Producto.Categoria.Id);
			objComando.Parameters.AddWithValue("@QuantityPerUnit", Producto.Presentacion);
			if (Producto.Precio != null)
			{
				objComando.Parameters.AddWithValue("@UnitPrice", Producto.Precio);
			}
			else
			{
				objComando.Parameters.AddWithValue("@UnitPrice", DBNull.Value);
			}
			if (Producto.Stock.NivelReposicion != null)
			{
				objComando.Parameters.AddWithValue("@ReorderLevel", Producto.Stock.NivelReposicion);
			}
			else
			{
				objComando.Parameters.AddWithValue("@ReorderLevel", DBNull.Value);
			}
			if (Producto.Stock.UnidadesStock != null)
			{
				 objComando.Parameters.AddWithValue("@UnitsInStock", Producto.Stock.UnidadesStock); 
			}
			else
			{
				objComando.Parameters.AddWithValue("@UnitsInStock", DBNull.Value); 
			}
			if (Producto.Stock.UnidadesPedidas != null)
			{
				objComando.Parameters.AddWithValue("@UnitsOnOrder", Producto.Stock.UnidadesPedidas);
			}
			else
			{
				objComando.Parameters.AddWithValue("@UnitsOnOrder", DBNull.Value);
			}
			objComando.Parameters.AddWithValue("@Discontinued", Producto.Descontinuado);
			objComando.CommandText = SQL;
			try
			{
				objConexion.Open();
				objComando.ExecuteNonQuery();
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
		}
		public void Actualizar(Producto Producto)
		{
			SQL = "UPDATE Products SET ";
			SQL = SQL + "ProductName=@ProductName, SupplierId=@SupplierId, CategoryId=@CategoryId, QuantityPerUnit=@QuantityPerUnit, UnitPrice=@UnitPrice, ReorderLevel=@ReorderLevel, UnitsInStock=@UnitsInStock, UnitsOnOrder=@UnitsOnOrder, Discontinued=@Discontinued ";
			SQL = SQL + "WHERE ProductId=@ProductId";
			objComando.Parameters.AddWithValue("@ProductName", Producto.Nombre);
			objComando.Parameters.AddWithValue("@SupplierId", Producto.Proveedor.Id);
			objComando.Parameters.AddWithValue("@CategoryId", Producto.Categoria.Id);
			objComando.Parameters.AddWithValue("@QuantityPerUnit", Producto.Presentacion);
			objComando.Parameters.AddWithValue("@UnitPrice", Producto.Precio);
			if (Producto.Stock.NivelReposicion != null)
			{
				objComando.Parameters.AddWithValue("@ReorderLevel", Producto.Stock.NivelReposicion);
			}
			else
			{
				objComando.Parameters.AddWithValue("@ReorderLevel", DBNull.Value);
			}
			if (Producto.Stock.UnidadesStock != null)
			{
				objComando.Parameters.AddWithValue("@UnitsInStock", Producto.Stock.UnidadesStock);
			}
			else
			{
				objComando.Parameters.AddWithValue("@UnitsInStock", DBNull.Value);
			}
			if (Producto.Stock.UnidadesPedidas != null)
			{
				objComando.Parameters.AddWithValue("@UnitsOnOrder", Producto.Stock.UnidadesPedidas);
			}
			else
			{
				objComando.Parameters.AddWithValue("@UnitsOnOrder", DBNull.Value);
			}
			objComando.Parameters.AddWithValue("@Discontinued", Producto.Descontinuado);
			objComando.Parameters.AddWithValue("@ProductId", Producto.Id);
			objComando.CommandText = SQL;
			try
			{
				objConexion.Open();
				objComando.ExecuteNonQuery();
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
		}
		public void Eliminar(int Id)
		{
			SQL = "DELETE FROM Products ";
			SQL = SQL + "WHERE ProductId=@ProductId";
			objComando.Parameters.AddWithValue("@ProductId", Id);
			objComando.CommandText = SQL;
			try
			{
				objConexion.Open();
				objComando.ExecuteNonQuery();
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
		}
	}
}
