using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class verProducto : Producto
    {
        public string verCategoria
        {
            get { return this.Categoria.Nombre; }
        }

        public string verProveedor
        {
            get { return this.Proveedor.Nombre; }
        }

        public int? verUnidadesStock
        {
            get { return this.Stock.UnidadesStock; }
        }
        public int? verUnidadesPedidas
        {
            get { return this.Stock.UnidadesPedidas; }
        }
        public int? verNivelReposicion
        {
            get { return this.Stock.NivelReposicion; }
        }
    }
}
