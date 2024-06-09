using Blazor.Shared.Models;
using Blazor.Shared.Services.Cliente;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Server.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClienteOpsController : ControllerBase
    {
        private readonly IClienteServices clienteServices;
        public ClienteOpsController(IClienteServices _clienteServices) 
        {
            clienteServices = _clienteServices;
        }


        [HttpGet]
        [Route("get-clientes-list")]
        public async Task<IActionResult> GetClientesList()
        {
            List<ClienteEntity> clientes = new List<ClienteEntity>();

            clientes = clienteServices.GetAllClientes().ToList(); // cambiar GetAllClientes

            return Ok(clientes);
        }


        [HttpPost]
        [Route("post-cliente")]
        public async Task<IActionResult> AddNewCliente(ClienteEntity clienteEntity)
        {
            try
            {
                clienteServices.AddCliente(clienteEntity); // cambiar a AddCliente
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        [Route("delete-cliente/{idCliente}")]
        public async Task<IActionResult> GetClientesList(int idCliente)
        {        
            clienteServices.DeleteCliente(idCliente);   // cambiar a DeleteCliente

            return Ok();
        }



        [HttpPost]
        [Route("update-cliente")]
        public async Task<IActionResult> UpdateCliente(ClienteEntity clienteEntity)
        {
            try
            {
                clienteServices.UpdateCliente(clienteEntity);   // cambiar a UpdateCliente
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
