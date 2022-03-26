using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{
    public class Usuario
    {
        public string Codigo { get; set; }
     
        public string Nombre { get; set; }
        public string Precio { get; set; }
        public string Existencia { get; set; }

        public Usuario()
        {
        }

        public String CodigoU { get; set; }
        public string Clave { get; set; }

        public Usuario(string codigo, string nombre, string precio, string existencia, string codigoU, string clave)
        {
            Codigo = codigo;
            Nombre = nombre;
            Precio = precio;
            Existencia = existencia;
            CodigoU = codigoU;
            Clave = clave;
        }
    }
}
