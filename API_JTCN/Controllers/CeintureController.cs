using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_JTCN.Controllers
{
    [Route("api/ceintures")]
    [ApiController]
    public sealed class CeintureController : ControllerBase
    {
        private readonly IServiceManager _service;

        public CeintureController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet("liste")]
        public IActionResult GetCeintures()
        {
            try
            {
                var belts = _service.Ceinture.GetAllCeinutres();
                return Ok(belts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetCeintureById([FromRoute] int id)
        {
            try
            {
                var belt = _service.Ceinture.GetCeintureById(id);
                return Ok(belt);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
