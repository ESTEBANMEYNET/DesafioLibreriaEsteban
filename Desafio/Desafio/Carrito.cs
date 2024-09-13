using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio
{
    public class Carrito
    {
        private List<(Libro libro, int cantidad)> items = new List<(Libro, int)>();

        public void Agregar(Libro libro, int cantidad)
        {
            items.Add((libro, cantidad));
        }

        public void MostrarCarrito()
        {
            Console.WriteLine("Carrito de compras:\n");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.libro.Titulo} Cantidad: {item.cantidad} Precio: {item.libro.Precio * item.cantidad}");
            }
            Console.WriteLine($"Total: {CalcularTotal()}");
        }

        public decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (var item in items)
            {
                total += item.libro.Precio * item.cantidad;
            }
            return total;
        }

        public List<(Libro libro, int cantidad)> ObtenerLibro()
        {
            return items;
        }
    }
}
