using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Shared.Models
{
    public class HuespedEntity
    {
        public int idHuesped { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; }
        public float CostoHospedaje { get; set; }
        public int idMascota { get; set; } // Llave foranea
    }
}