using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_JTCN.Controllers
{
    [Route("api/cotisations")]
    [ApiController]
    public class CotisationController : ControllerBase
    {
        private readonly IServiceManager _service;

        public CotisationController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet("liste")]
        public IActionResult GetCotisations()
        {
            try
            {
                var cotisations = _service.Cotisation.GetAllCotisations();
                return Ok(cotisations);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
