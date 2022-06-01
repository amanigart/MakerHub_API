using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_JTCN.Controllers
{
    [Route("api/membres")]
    [ApiController]
    public class MembreController : ControllerBase
    {
        private readonly IServiceManager _service;

        public MembreController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet("liste")]
        public IActionResult GetMemberList()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var members = _service.Membre.GetMemberList();
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);

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
    }
}
