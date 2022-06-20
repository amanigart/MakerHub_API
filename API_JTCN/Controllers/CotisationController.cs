using BusinessLogicLayer.Interfaces;
using DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_JTCN.Controllers
{
    [Authorize]
    [Route("api/cotisations")]
    [ApiController]
    public class CotisationController : ControllerBase
    {
        private readonly IServiceManager _service;

        public CotisationController(IServiceManager service)
        {
            _service = service;
        }

        /// <summary>
        /// Action permettant de récupérer la liste de toutes les cotisations.
        /// </summary>
        /// <response code="200">Retourne la liste des cotisations</response>
        /// <response code="400">Retourne un message d'erreur.</response>
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

        /// <summary>
        /// Action permettant de créer un nouveau membre.
        /// </summary>
        /// <param name="membership">Un modèle CotisationForCreationDto</param>
        /// <response code="204">Ne retourne rien.</response>
        /// <response code="400">Retourne un message d'erreur si l'objet est null.</response>
        /// <response code="422">Retourne un message d'erreur en cas demodèle non-valide.</response>
        [HttpPost]
        public IActionResult CreateMembership([FromBody] CotisationForCreationDto membership)
        {
            if (membership is null)
                return BadRequest("L'objet CotisationForCreationDto est null.");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            _service.Cotisation.CreateCotisationForMember(membership);
            return NoContent();
        }

        /// <summary>
        /// Action permettant d'archiver ou désarchiver une cotisation.
        /// </summary>
        /// <param name="id">L'identifiant de la cotisation (idCotisation)</param>
        /// <response code="204">Ne retourne rien.</response>
        /// <response code="400">Retourne un message d'erreur.</response>
        [HttpPost("archivage/{id:int}")]
        public IActionResult ChangeArchiveStatus([FromRoute] int id)
        {
            try
            {
                _service.Cotisation.SwitchArchiveStatus(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Action permettant de modifier l'état d'un paiement une cotisation.
        /// </summary>
        /// <param name="id">L'identifiant de la cotisation (idCotisation)</param>
        /// <response code="204">Ne retourne rien.</response>
        /// <response code="400">Retourne un message d'erreur.</response>
        [HttpPost("paiement/{id:int}")]
        public IActionResult ChangePaymentStatus([FromRoute] int id)
        {
            try
            {
                _service.Cotisation.SwitchPaymentStatus(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
