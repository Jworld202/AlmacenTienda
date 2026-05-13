using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmacenTienda.Models
{
    public class Proveedor
    {
        public int IdProveedor { get; set; }
        public string Ruc { get; set; }
        public string NombreEmpresa { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string ContactoNombre { get; set; }
        public bool Activo { get; set; }
    }
}
