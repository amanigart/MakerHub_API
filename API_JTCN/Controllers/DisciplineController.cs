using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_JTCN.Controllers
{
    [Authorize]
    [Route("api/disciplines")]
    [ApiController]
    public sealed class DisciplineController : ControllerBase
    {
        private readonly IServiceManager _service;

        public DisciplineController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet("liste")]
        public IActionResult GetDisciplines()
        {
            try
            {
                var disciplines = _service.Discipline.GetAllDisciplines();
                return Ok(disciplines);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
