﻿using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_JTCN.Controllers
{
    [Route("api/tarifs")]
    [ApiController]
    public class TarifController : ControllerBase
    {
        private readonly IServiceManager _service;

        public TarifController(IServiceManager service)
        {
            _service = service;
        }

        /// <summary>
        /// Action permettant de récupérer la liste complète des formules tarifaires.
        /// </summary>
        /// <response code="200">Retourne une collection de tarifs.</response>
        /// <response code="400">Retourne un message d'erreur.</response>
        [HttpGet("liste")]
        public IActionResult GetTarifs()
        {
            try
            {
                var pricePlans = _service.Tarif.GetAllTarifs();
                return Ok(pricePlans);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Action permettant de récupérer un tarif sur base de son id.
        /// </summary>
        /// <param name="id">L'id du tarif (idTarif).</param>
        /// <response code="200">Retourne un tarif.</response>
        /// <response code="400">Retourne un message d'erreur ("Ce tarif n'existe pas").</response>
        [HttpGet("{id:int}")]
        public IActionResult GetTarif([FromRoute] int id)
        {
            try
            {
                var pricePlan = _service.Tarif.GetTarifById(id);
                return Ok(pricePlan);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}