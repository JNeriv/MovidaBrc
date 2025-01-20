using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovidaBrcSharedLibrary.Contracts;
using MovidaBrcSharedLibrary.Models;
using MovidaBrcSharedLibrary.Responses;

namespace MovidaBrc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FiestaController(IFiesta fiestaService) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<Fiesta>> GetAllFiestas()
        {
            var fiestas = await fiestaService.GetAllFiestas(); return Ok(fiestas);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse>> AddFiesta(Fiesta model)
        {
            if (model is null) return BadRequest("El modelo está vacío");
            var response = await fiestaService.AddFiesta(model);
            return Ok(response);
        }



    }
}
