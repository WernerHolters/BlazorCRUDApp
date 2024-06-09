using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Shared.Models
{
    public class PersonaEntity
    {
        public int idPersona { get; set; }

        public string CI { get; set; }

        public string Nombre { get; set; }

        public string Telefono { get; set; }
    }
}

