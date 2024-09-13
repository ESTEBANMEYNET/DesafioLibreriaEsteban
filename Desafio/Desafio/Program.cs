using Desafio;
using System;

class Program
{
    static void Main(string[] args)
    {
        Venta sistema = new Venta();

        Console.Write("Ingrese su nombre: ");
        string nombre = Console.ReadLine();
        Usuario usuario = sistema.Login(nombre);

        if (usuario != null)
        {
            sistema.MostrarRubros();

            Console.WriteLine("Seleccione un género: ");
            int generoSeleccionado = int.Parse(Console.ReadLine());
            string genero = sistema.generosDisponibles[generoSeleccionado - 1];

            sistema.MostrarCatalogoPorGenero(genero);

            Carrito carrito = new Carrito();
            bool agregarLibros = true;
            while (agregarLibros)
            {
                Console.WriteLine("Ingrese el título del libro que desea comprar:");
                string tituloLibro = Console.ReadLine();

                Libro libroSeleccionado = sistema.Inventario.Find(libro => libro.Titulo.ToLower() == tituloLibro.ToLower() && libro.Genero.ToLower() == genero.ToLower());

                if (libroSeleccionado != null)
                {
                    Console.Write("Ingrese la cantidad: ");
                    int cantidad = int.Parse(Console.ReadLine());
                    carrito.Agregar(libroSeleccionado, cantidad);
                }
                else
                {
                    Console.WriteLine("\nLibro no encontrado.");
                }

                Console.Write("¿Desea agregar otro libro? (s/n): ");
                agregarLibros = Console.ReadLine().ToLower() == "s";
            }

            carrito.MostrarCarrito();
            Console.Write("¿Desea confirmar la compra? (s/n): ");
            if (Console.ReadLine().ToLower() == "s")
            {
                sistema.ConfirmarCompra(usuario, carrito);
            }
            else
            {
                Console.WriteLine("Compra cancelada.\n");
            }
        }
    }
}
