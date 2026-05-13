using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmacenTienda.Models
{
    public class Venta
    {
        //esto es para salida_ventas
        public int IdVenta { get; set; }
        public DateTime FechaVenta { get; set; }
        public int? IdCliente { get; set; }  // Puede ser NULL
        public int IdEmpleado { get; set; }
        public string NumeroTicket { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Impuesto { get; set; }
        public decimal TotalVenta { get; set; }
        public string MetodoPago { get; set; }
        public string Estado { get; set; }

        // Propiedades auxiliares
        public string NombreCliente { get; set; }
        public string NombreEmpleado { get; set; }
    }
}
