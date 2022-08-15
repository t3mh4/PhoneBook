using MassTransit;
using MassTransit.DependencyInjection;
using MassTransit.RabbitMqTransport;
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
    }
}
