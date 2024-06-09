using Blazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Shared.Services.Cliente
{
    public interface IClienteServices
    {
        public IEnumerable<ClienteEntity> GetAllClientes();
        public void AddCliente(ClienteEntity cliente);
        public void UpdateCliente(ClienteEntity cliente);
        public void DeleteCliente(int? idCliente);
    }
}
