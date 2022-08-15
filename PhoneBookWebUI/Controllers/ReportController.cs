using MassTransit;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Core.Enums;
using PhoneBook.Dtos;
using PhoneBookWebUI.Helper;

namespace PhoneBookWebUI.Controllers
{
    public class ReportController : BaseContoller
    {
        public async Task<ActionResult> Index()
        {
            
            return View(await _httpClient.GetFromJsonAsync<List<ReportDto>>("report/getall"));
        }

        public async Task<ActionResult> CreateRequest([FromServices] IBus bus)
        {
            await bus.Publish(new Command() { Cmd = EnumReport.Command.Generate });
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Download(string fullpath)
        {
            var stream = System.IO.File.OpenRead(fullpath);
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", Path.GetFileName(fullpath));
        }

        public async Task<ActionResult>Details(Guid uuid)
        {
            return View(await _httpClient.GetFromJsonAsync<ReportDetailDto>("report/GetDetailsByUUID?uuid=" + uuid));
        }
    }
}
