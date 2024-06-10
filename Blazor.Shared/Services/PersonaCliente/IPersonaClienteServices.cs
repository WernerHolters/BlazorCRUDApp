using Blazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Shared.Services.PersonaCliente
{
    public interface IPersonaClienteServices
    {
        public void AddPersonaCliente(PersonaClienteEntity personacliente);
    }
}
