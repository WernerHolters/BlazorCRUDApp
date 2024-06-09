using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Shared.Models
{
    public class MascotaEntity
    {
        public int idMascota { get; set; }
        public string Nombre { get; set; }
        public string Especie { get; set; }
        public string Raza { get; set; }
        public string Color { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public float PesoActual { get; set; }
        public int idCliente { get; set; } // Clave foránea
    }
}
