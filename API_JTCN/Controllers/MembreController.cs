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

        //[HttpGet("listeasync")]
        //public async Task<IActionResult> GetMemberListAsync()
        //{
        //    var watch = System.Diagnostics.Stopwatch.StartNew();
        //    var members = await _service.Membre.GetMemberListAsync();
        //    watch.Stop();
        //    System.Console.WriteLine(watch.ElapsedMilliseconds);

        //    return Ok(members);
        //}

        [HttpDelete("supprimer")]
        public IActionResult DeleteMember(int id)
        {
            _service.Membre.DeleteMember(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetMemberDetails(int id)
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
