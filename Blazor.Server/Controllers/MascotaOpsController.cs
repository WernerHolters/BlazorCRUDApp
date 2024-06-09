using Blazor.Shared.Models;
using Blazor.Shared.Services.Mascota;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Server.Controllers
{
    [Route("api/mascotas")]
    [ApiController]
    public class MascotaOpsController : ControllerBase
    {
        private readonly IMascotaServices mascotaServices;
        public MascotaOpsController(IMascotaServices _mascotaServices)
        {
            mascotaServices = _mascotaServices;
        }


        [HttpGet]
        [Route("get-mascotas-list")]
        public async Task<IActionResult> GetMascotasList()
        {
            List<MascotaEntity> mascotas = new List<MascotaEntity>();

            mascotas = mascotaServices.GetAllMascotas().ToList();

            return Ok(mascotas);
        }


        [HttpPost]
        [Route("post-mascota")]
        public async Task<IActionResult> AddNewMascota(MascotaEntity mascotaEntity)
        {
            try
            {
                mascotaServices.AddMascota(mascotaEntity);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        [Route("delete-mascota/{idMascota}")]
        public async Task<IActionResult> GetMascotasList(int idMascota)
        {
            mascotaServices.DeleteMascota(idMascota);

            return Ok();
        }

        [HttpPost]
        [Route("update-mascota")]
        public async Task<IActionResult> UpdateMascota(MascotaEntity mascotaEntity)
        {
            try
            {
                mascotaServices.UpdateMascota(mascotaEntity);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /*=========================================================*/
        /*[HttpGet]
        [Route("get-cliente-mascotas-")]
        public async Task<IActionResult> GetClienteMascota()
        {
            List<MascotaEntity> mascotas = new List<MascotaEntity>();

            mascotas = mascotaServices.GetClienteMascota().ToList();

            return Ok(mascotas);
        }*/
    }
}
