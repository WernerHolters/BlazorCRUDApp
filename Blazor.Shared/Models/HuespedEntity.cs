using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Shared.Models
{
    public class HuespedEntity
    {
        public int idHuesped { get; set; }

        [Required(ErrorMessage = "Required")]
        public DateTime FechaIngreso { get; set; }

        [Required(ErrorMessage = "Required")]
        public DateTime FechaSalida { get; set; }

        [Required(ErrorMessage = "Required")]
        public float CostoHospedaje { get; set; }

        [Required(ErrorMessage = "Required")]
        public int idMascota { get; set; } // Llave foranea
    }
}