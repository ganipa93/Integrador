using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class admProveedores
    {
        public List<Proveedor> Listar()
        {
            return new dbProveedores().Listar();
        }
    }
}
