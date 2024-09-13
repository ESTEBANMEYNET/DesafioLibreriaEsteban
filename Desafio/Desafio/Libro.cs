using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio
{
    public class Libro
    {
        public string Titulo { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Genero { get; set; }

        public Libro(string titulo, decimal precio, int stock, string genero)
        {
            Titulo = titulo;
            Precio = precio;
            Stock = stock;
            Genero = genero;
        }
    }
}
