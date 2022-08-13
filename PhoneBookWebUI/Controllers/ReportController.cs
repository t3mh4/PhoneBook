using Microsoft.AspNetCore.Mvc;
using PhoneBookWebUI.Helper;

namespace PhoneBookWebUI.Controllers
{
    public class ReportController : BaseContoller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
