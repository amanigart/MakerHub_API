using API_JTCN.Identity;
using BusinessLogicLayer.Interfaces;
using DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace API_JTCN.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IServiceManager _service;
        private readonly ITokenService _tokenService;

        public AuthController(IServiceManager service, ITokenService tokenService)
        {
            _service = service;
            _tokenService = tokenService;
        }

        /// <summary>
        /// Formulaire de login/authentification.
        /// </summary>
        /// <param name="form">Prend un LoginFormDto (Login, Password) en paramètre</param>
        /// <response code="200">Retourne un token contenant: id utilisateur + rôle</response>
        /// <response code="400">Retourne un message d'erreur si login ou mot de passe sont incorrects</response>
        [HttpPost]
        public IActionResult Post([FromBody] LoginFormDto form)
        {
            try
            {
                AppUtilisateurDto userDto = _service.Authentication.Login(form.Login, form.Password);
                string token = _tokenService.GenerateToken(userDto.Id, userDto.Role);

                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
