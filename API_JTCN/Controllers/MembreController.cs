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

        [HttpGet("liste")]
        public IActionResult GetMemberList()
        {
            var members = _service.Membre.GetMemberList();
            return Ok(members);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteMember([FromRoute] int id)
        {
            _service.Membre.DeleteMember(id);
            return Ok();
        }

        [HttpGet("{id:int}")]
        public IActionResult GetMemberDetails([FromRoute] int id)
        {
            try
            {
                MembreDetailDto member = _service.Membre.GetMemberDetail(id);
                return Ok(member);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
