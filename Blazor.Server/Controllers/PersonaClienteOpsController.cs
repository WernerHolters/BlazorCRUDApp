using Blazor.Shared.Models;
using Blazor.Shared.Services.Mascota;
using Blazor.Shared.Services.PersonaCliente;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Server.Controllers
{
    [Route("api/persona-cliente")]
    [ApiController]
    public class PersonaClienteOpsController : ControllerBase
    {
        private readonly IPersonaClienteServices personaclienteServices;
        public PersonaClienteOpsController(IPersonaClienteServices _personaclienteServices)
        {
            personaclienteServices = _personaclienteServices;
        }

        [HttpPost]
        [Route("post-persona-cliente")]
        public async Task<IActionResult> AddNewPersonaCliente(PersonaClienteEntity personaclienteEntity)
        {
            try
            {
                personaclienteServices.AddPersonaCliente(personaclienteEntity);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
