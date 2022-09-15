using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto
    {
        public Producto()
        {
            this.Categoria = new Categoria();
            this.Proveedor = new Proveedor();
            this.Stock = new Stock();
        }
        
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Proveedor Proveedor { get; set; }
        public Categoria Categoria { get; set; }
        public string Presentacion { get; set; }
        public decimal? Precio { get; set; }
        public Stock Stock { get; set; }
        public bool Descontinuado { get; set; }
    }
}
