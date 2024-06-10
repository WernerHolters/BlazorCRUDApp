using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Shared.Models
{
    public class MascotaEntity
    {
        public int idMascota { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Especie { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Raza { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Required")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Required")]
        public float PesoActual { get; set; }

        [Required(ErrorMessage = "Required")]
        public int idCliente { get; set; } // Clave foránea
    }
}
