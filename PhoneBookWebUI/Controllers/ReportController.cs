using Microsoft.AspNetCore.Mvc;
using PhoneBook.Dtos;
using PhoneBookWebUI.Helper;

namespace PhoneBookWebUI.Controllers
{
    public class ReportController : BaseContoller
    {
        public async Task<IActionResult> Index()
        {
            return View(await _httpClient.GetFromJsonAsync<List<ReportDto>>("report/getall"));
        }
    }
}
