using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class admProductos
    {
        dbProductos obj = new dbProductos();
        public List<verProducto> ListarPorCategoria(Categoria Categoria)
        {
            return obj.ListarPorCategoria(Categoria);
        }
        public List<verProducto> ListarPorCategoria(int Id_Categoria)
        {
            return obj.ListarPorCategoria(Id_Categoria);
        }
        public Producto Listar(int Id)
        {
            return obj.Listar(Id);
        }

        public List<verProducto> Listar()
        {
            return obj.Listar();
        }

        public void Agregar(Producto Producto)
        {
            obj.Agregar(Producto);
        }

        public void Actualizar(Producto Producto)
        {
            obj.Actualizar(Producto);
        }

        public void Eliminar(int Id)
        {
            obj.Eliminar(Id);
        }
    }
}
