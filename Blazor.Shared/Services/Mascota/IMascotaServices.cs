using Blazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Shared.Services.Mascota
{
    public interface IMascotaServices
    {
        public IEnumerable<MascotaEntity> GetAllMascotas();

        public void AddMascota(MascotaEntity mascota);

        public void UpdateMascota(MascotaEntity mascota);

        public void DeleteMascota(int? idMascota);
    }
}
