using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmacenTienda.Models
{
    public class EntradaCompra
    {
        public int IdEntrada { get; set; }
        public DateTime FechaEntrada { get; set; }
        public int IdProveedor { get; set; }
        public int IdEmpleado { get; set; }
        public string NumeroFactura { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Impuesto { get; set; }
        public decimal TotalCompra { get; set; }
        public string Estado { get; set; }
    }
}
