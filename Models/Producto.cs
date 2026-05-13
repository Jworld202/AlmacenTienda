using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmacenTienda.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string CodigoBarras { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public int StockMaximo { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int IdCategoria { get; set; }
        public int IdMarca { get; set; }
        public int IdProveedor { get; set; }
        public bool Activo { get; set; }

        // Propiedades de navegación (opcionales, para mostrar nombres)
        public string NombreCategoria { get; set; }
        public string NombreMarca { get; set; }
        public string NombreProveedor { get; set; }
    }
}
