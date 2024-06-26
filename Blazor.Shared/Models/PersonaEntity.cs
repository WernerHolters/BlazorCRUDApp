﻿using System;
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

        [Required(ErrorMessage = "Required")]
        public string CI { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Telefono { get; set; }
    }
}

