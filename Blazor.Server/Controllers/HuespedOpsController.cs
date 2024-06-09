using Blazor.Shared.Models;
using Blazor.Shared.Services.Huesped;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Server.Controllers
{
    [Route("api/huespedes")]
    [ApiController]
    public class HuespedOpsController : ControllerBase
    {
        private readonly IHuespedServices huespedServices;
        public HuespedOpsController(IHuespedServices _huespedServices)
        {
            huespedServices = _huespedServices;
        }


        [HttpGet]
        [Route("get-huespedes-list")]
        public async Task<IActionResult> GetHuespedesList()
        {
            List<HuespedEntity> huespedes = new List<HuespedEntity>();

            huespedes = huespedServices.GetAllHuespedes().ToList();

            return Ok(huespedes);
        }


        [HttpPost]
        [Route("post-huesped")]
        public async Task<IActionResult> AddNewHuesped(HuespedEntity huespedEntity)
        {
            try
            {
                huespedServices.AddHuesped(huespedEntity);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        [Route("delete-huesped/{idHuesped}")]
        public async Task<IActionResult> GetHuespedList(int idHuesped)
        {
            huespedServices.DeleteHuesped(idHuesped);

            return Ok();
        }

        [HttpPost]
        [Route("update-huesped")]
        public async Task<IActionResult> UpdateHuesped(HuespedEntity huespedEntity)
        {
            try
            {
                huespedServices.UpdateHuesped(huespedEntity);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
