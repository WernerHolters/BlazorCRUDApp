using Blazor.Shared.Models;
using Blazor.Shared.Services.Persona;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Server.Controllers
{
    [Route("api/personas")]
    [ApiController]
    public class PersonaOpsController : ControllerBase
    {
        private readonly IPersonaServices personaServices;
        public PersonaOpsController(IPersonaServices _personaServices) {

            personaServices = _personaServices;
        }


        [HttpGet]
        [Route("get-personas-list")]
        public async Task<IActionResult> GetPersonasList()
        {
            List<PersonaEntity> personas = new List<PersonaEntity>();

            personas = personaServices.GetAllPersonas().ToList();

            return Ok(personas);
        }


        [HttpPost]
        [Route("post-persona")]
        public async Task<IActionResult> AddNewPersona(PersonaEntity personaEntity)
        {
            try
            {
                personaServices.AddPersona(personaEntity);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        [Route("delete-persona/{idPersona}")]
        public async Task<IActionResult> GetPersonasList(int idPersona)
        {        
            personaServices.DeletePersona(idPersona); 

            return Ok();
        }


        [HttpPost]
        [Route("update-persona")]
        public async Task<IActionResult> UpdatePersona(PersonaEntity personaEntity)
        {
            try
            {
                personaServices.UpdatePersona(personaEntity);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
