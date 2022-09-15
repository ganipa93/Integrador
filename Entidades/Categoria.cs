using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Categoria
    {
        public Categoria()
        {
        }
        public Categoria(int Id, string Nombre)
        {
            this.Id = Id;
            this.Nombre = Nombre;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
