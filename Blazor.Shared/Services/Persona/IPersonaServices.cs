using Blazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Shared.Services.Persona
{
    public interface IPersonaServices
    {
        public IEnumerable<PersonaEntity> GetAllPersonas();

        public void AddPersona(PersonaEntity persona);

        public void UpdatePersona(PersonaEntity persona);

        public void DeletePersona(int? idPersona);
    }
}
