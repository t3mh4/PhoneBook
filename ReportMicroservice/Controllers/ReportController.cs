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

        [HttpGet("Test")]
        public IActionResult Test()
        {
            return Ok("Tarih ve Saat : "+DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"));
        }
    }
}
