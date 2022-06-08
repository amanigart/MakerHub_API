using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_JTCN.Controllers
{
    [Route("api/horaires")]
    [ApiController]
    public sealed class HoraireController : ControllerBase
    {
        private readonly IServiceManager _service;

        public HoraireController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet("liste")]
        public IActionResult GetHoraires()
        {
            try
            {
                var schedules = _service.Horaire.getAllHoraires();
                return Ok(schedules);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetHoraire([FromRoute] int id)
        {
            try
            {
                var schedule = _service.Horaire.getHoraireById(id);
                return Ok(schedule);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
