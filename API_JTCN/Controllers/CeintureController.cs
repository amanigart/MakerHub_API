using BusinessLogicLayer.Interfaces;
using DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_JTCN.Controllers
{
    [Authorize]
    [Route("api/ceintures")]
    [ApiController]
    public sealed class CeintureController : ControllerBase
    {
        private readonly IServiceManager _service;

        public CeintureController(IServiceManager service) => _service = service;

        /// <summary>
        /// Action permettant de récupérer la liste des ceintures.
        /// </summary>
        /// <response code="200">Retourne une collection comprenant les ceintures de jiu-jitsu et tai-jitsu.</response>
        /// <response code="400">Retourne un message d'erreur.</response>
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

        /// <summary>
        /// Action permettant de récupérer le détail d'une ceinture sur base de son id.
        /// </summary>
        /// <param name="id">Prend un id de ceinture (idCeinture) en paramètre.</param>
        /// <response code="200">Retourne un objet ceintureDto.</response>
        /// <response code="400">Retourne un message d'erreur.</response>
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

        [HttpPost("ceinture-membre")]
        public IActionResult CreateBelt([FromBody] CeintureMembreForCreationDto belt)
        {
            if (belt is null)
                return BadRequest("L'objet CeintureMembreForCreationDto est null.");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            _service.Membre.CreateNewBeltForMember(belt);
            return NoContent();
        }
    }
}
