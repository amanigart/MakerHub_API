using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_JTCN.Controllers
{
    [Route("api/ceintures")]
    [ApiController]
    public sealed class CeintureController : ControllerBase
    {
        // private readonly ICeintureService _ceintureService;

        public CeintureController()
        {

        }

        [HttpGet]
        public IActionResult GetCeintures()
        {
            return Ok();
        }
    }
}
