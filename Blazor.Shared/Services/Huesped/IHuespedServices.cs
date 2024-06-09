using Blazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Shared.Services.Huesped
{
    public interface IHuespedServices
    {
        public IEnumerable<HuespedEntity> GetAllHuespedes();

        public void AddHuesped(HuespedEntity huesped);

        public void UpdateHuesped(HuespedEntity huesped);

        public void DeleteHuesped(int? idHuesped);
    }
}
