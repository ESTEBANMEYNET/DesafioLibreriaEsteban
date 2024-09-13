using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio
{
    public class Compra
    {
        public Usuario Usuario { get; set; }
        public List<(Libro libro, int cantidad)> LibrosComprados { get; set; }
        public decimal Total { get; set; }
        public string NumeroTarjeta { get; set; }
        public string FechaVencimiento { get; set; }
        public string CodigoSeguridad { get; set; }

        public Compra(Usuario usuario, List<(Libro libro, int cantidad)> librosComprados, decimal total)
        {
            Usuario = usuario;
            LibrosComprados = librosComprados;
            Total = total;
        }

        public void ProcesarPago(string numeroTarjeta, string fechaVencimiento, string codigoSeguridad)
        {
            NumeroTarjeta = numeroTarjeta;
            FechaVencimiento = fechaVencimiento;
            CodigoSeguridad = codigoSeguridad;
            Console.WriteLine("El pago fue procesado correctamente.\n");
        }
    }

}
