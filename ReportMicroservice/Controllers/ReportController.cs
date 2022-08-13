using Microsoft.AspNetCore.Mvc;
using ReportMicroservice.Managers;

namespace ReportMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportManager _manager;
        public ReportController(IReportManager manager)
        {
            _manager = manager;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _manager.GetAll());
        }

    }
}
