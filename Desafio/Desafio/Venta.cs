using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio
{
    public class Venta
    {
        private List<Usuario> clientesRegistrados;
        public List<Libro> Inventario { get; set; }
        public List<string> generosDisponibles;

        public Venta()
        {
            clientesRegistrados = new List<Usuario>
        {
            new Usuario("Esteban"),
            new Usuario("Joaquin")
        };

            Inventario = new List<Libro>
        {
            new Libro("Don Quijote de la Mancha", 14.99m, 5, "Literatura"),
            new Libro("Cien años de soledad", 6.99m, 15, "Literatura"),
            new Libro("El Principito", 9.99m, 20, "Fantasía"),
            new Libro("El Señor de los Anillos", 30.99m, 8, "Fantasía"),
            new Libro("Harry Potter y la Piedra Filosofal", 24.99m, 12, "Ciencia Ficción"),
            new Libro("Dune", 21.99m, 17, "Ciencia Ficción")
        };

            generosDisponibles = new List<string> { "Literatura", "Ciencia Ficción", "Fantasía" };
        }

        public Usuario Login(string nombre)
        {
            foreach (var cliente in clientesRegistrados)
            {
                if (cliente.Nombre.ToLower() == nombre.ToLower())
                {
                    Console.WriteLine("Acceso exitoso.\n");
                    return cliente;
                }
            }
            Console.WriteLine("Usuario no registrado.\n");
            return null;
        }

        public void MostrarRubros()
        {
            Console.WriteLine("Géneros disponibles:");
            for (int i = 0; i < generosDisponibles.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {generosDisponibles[i]}");
            }
        }

        public void MostrarCatalogoPorGenero(string genero)
        {
            Console.WriteLine($"Catálogo de libros disponibles en {genero}:");
            foreach (var libro in Inventario)
            {
                if (libro.Genero.ToLower() == genero.ToLower())
                {
                    Console.WriteLine($"{libro.Titulo} - Precio: {libro.Precio:C} - Stock: {libro.Stock}");
                }
            }
        }

        public bool VerificarStock(Carrito carrito)
        {
            foreach (var item in carrito.ObtenerLibro())
            {
                if (item.libro.Stock < item.cantidad)
                {
                    Console.WriteLine($"No hay suficiente stock para el libro {item.libro.Titulo}. Stock disponible: {item.libro.Stock}");
                    return false;
                }
            }
            return true;
        }

        public void ConfirmarCompra(Usuario usuario, Carrito carrito)
        {
            if (!VerificarStock(carrito))
            {
                Console.WriteLine("No se puede completar la compra. Ajuste las cantidades o elimine libros.");
                return;
            }

            decimal total = carrito.CalcularTotal();
            Console.WriteLine($"Total a pagar: {total}");
            Console.Write("Ingrese el número de tarjeta: ");
            string numeroTarjeta = Console.ReadLine();
            Console.Write("Ingrese la fecha de vencimiento (MM/AA): ");
            string fechaVencimiento = Console.ReadLine();
            Console.Write("Ingrese el código de seguridad: ");
            string codigoSeguridad = Console.ReadLine();

            Compra compra = new Compra(usuario, carrito.ObtenerLibro(), total);
            compra.ProcesarPago(numeroTarjeta, fechaVencimiento, codigoSeguridad);

            foreach (var item in carrito.ObtenerLibro())
            {
                item.libro.Stock -= item.cantidad;
            }
            Console.WriteLine("Compra finalizada. Gracias por su compra.");
        }
    }

}
