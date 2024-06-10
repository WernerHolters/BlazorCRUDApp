using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Shared.Models
{
    public class ClienteEntity
    {
        public int idCliente { get; set; }
        
        [Required(ErrorMessage = "Required")]
        public string PrimerApellido { get; set; }
        [Required(ErrorMessage = "Required")]
        public string CuentaBanco { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Telefono { get; set; }
    }
}

