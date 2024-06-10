using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Shared.Models
{
    public class PersonaClienteEntity
    {
        [Required(ErrorMessage = "Required")]
        public DateTime FechaAsociacion { get; set; }
        [Required(ErrorMessage = "Required")]
        public int idPersona { get; set; } // Llave foranea
        [Required(ErrorMessage = "Required")]
        public int idCliente { get; set; } // Llave foranea
    }
}
