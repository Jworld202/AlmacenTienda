using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmacenTienda.Models
{
    public class Kardex
    {
        public int IdKardex { get; set; }
        public int IdProducto { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public string TipoMovimiento { get; set; } // 'ENTRADA' o 'SALIDA'
        public int Cantidad { get; set; }
        public int StockResultante { get; set; }
        public string Detalle { get; set; }
        // Propiedad auxiliar
        public string NombreProducto { get; set; }
    }
}
