using Entidades;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class admCategorias
    {
        public List<Categoria> Listar()
        {
            return new dbCategorias().Listar();
        }
    }
}
