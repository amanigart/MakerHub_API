using BusinessLogicLayer.Interfaces;
using DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_JTCN.Controllers
{
    [Route("api/horaires")]
    [ApiController]
    public sealed class HoraireController : ControllerBase
    {
        private readonly IServiceManager _service;

        public HoraireController(IServiceManager service) => _service = service;

        /// <summary>
        /// Action permettant de récupérer la liste deses horaires des jours d'entraînement.
        /// </summary>
        /// <response code="200">Retourne une collection d'horaires d'entraînement.</response>
        /// <response code="400">Retourne un message d'erreur.</response>
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


        /// <summary>
        /// Action permettant de récupérer un horaire d'entraînement sur base de son id.
        /// </summary>
        /// <param name="id">Prend un id d'horaire (idHoraire) en paramètre, via la route.</param>
        /// <response code="200">Retourne un horaire d'entraînement.</response>
        /// <response code="400">Retourne un message d'erreur.</response>
        [Authorize]
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


        /// <summary>
        /// Action permettant de mettre à jour un horaire existant.
        /// </summary>
        /// <param name="schedule">Prend un HoraireDto en paramètre.</param>
        /// <response code="204">Ne retourne rien</response>
        /// <response code="400">Retourne un message d'erreur.</response>
        /// <response code="422">Retourne les erreurs de validation du modèle.</response>
        [Authorize]
        [HttpPost]
        public IActionResult UpdateHoraire([FromBody] HoraireDto schedule)
        {
            if (schedule is null)
                return BadRequest("L'objet HoraireDto est null.");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            _service.Horaire.UpdateHoraire(schedule);
            return NoContent();
        }
    }
}
