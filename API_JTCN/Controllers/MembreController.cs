using BusinessLogicLayer.Interfaces;
using DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_JTCN.Controllers
{
    [Route("api/membres")]
    [ApiController]
    public sealed class MembreController : ControllerBase
    {
        private readonly IServiceManager _service;

        public MembreController(IServiceManager service)
        {
            _service = service;
        }

        /// <summary>
        /// Action permettant de récupérer la liste de tous les membres du club (actifs et inactifs).
        /// </summary>
        /// <response code="200">Retourne une collection de membres (uniquement avec: id, nom, prénom, status).</response>
        /// <response code="400">Retourne un message d'erreur.</response>
        [HttpGet("liste")]
        public IActionResult GetMemberList()
        {
            var members = _service.Membre.GetMemberList();
            return Ok(members);
        }


        /// <summary>
        /// Action permettant de supprimer (soft delete) un membre sur base de son id.
        /// </summary>
        /// <param name="id">Prend un id de membre (idMembre) en paramètre.</param>
        /// <response code="204">Ne retourne rien.</response>
        /// <response code="400">Retourne un message d'erreur.</response>
        [HttpDelete("{id:int}")]
        public IActionResult DeleteMember([FromRoute] int id)
        {
            _service.Membre.DeleteMember(id);
            return NoContent();
        }


        /// <summary>
        /// Action permettant de ré-activer un membre (estActif = true)
        /// </summary>
        /// <param name="id">Prend l'id d'un membre (idMembre) en paramètre.</param>
        /// <response code="204">Ne retourne rien.</response>
        /// <response code="400">Retourne un message d'erreur.</response>
        [HttpPost("{id:int}")]
        public IActionResult ActivateMember([FromRoute] int id)
        {
            try
            {
                _service.Membre.ActivateMember(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Action permettant de récupérer les infos détaillées d'un membre.
        /// </summary>
        /// <param name="id">Prend un id de membre (idMembre) en paramètre.</param>
        /// <response code="200">Retourne un membre détaillé.</response>
        /// <response code="400">Retourne un message d'erreur si le membre n'existe pas.</response>
        [HttpGet("{id:int}")]
        public IActionResult GetMemberDetails([FromRoute] int id)
        {
            try
            {
                MembreDto member = _service.Membre.GetMemberDetail(id);
                return Ok(member);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Action permettant d'inscrire un nouveau membre.
        /// </summary>
        /// <param name="member"></param>
        /// <response code="204">Retourne un code 200.</response>
        /// <response code="400">Retourne un message d'erreur.</response>
        [HttpPost("inscription")]
        public IActionResult CreateMember([FromBody] MembreForCreationDto member)
        {
            try
            {
                _service.Membre.CreateNewMember(member);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
