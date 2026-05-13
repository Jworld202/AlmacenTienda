using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmacenTienda.Models
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string Dni { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApellidoEmpleado { get; set; }
        public string Puesto { get; set; }
        public decimal Salario { get; set; }
        public DateTime FechaContratacion { get; set; }
        public bool Activo { get; set; }
    }
}
