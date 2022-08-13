using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Dtos;

namespace PhoneBookWebUI.Controllers
{
    public class ContactInfoController : Controller
    {
        private readonly HttpClient _httpClient;
        public ContactInfoController()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:17000")
            };
        }
        public async Task<ActionResult> Index(Guid ContactUUID)
        {
            var contactInfoList = await _httpClient.GetFromJsonAsync<List<ContactInfoDto>>("contactinfo/getallbycontactUUID?contactUUID=" + ContactUUID);
            return View(contactInfoList);
        }

        // GET: ContactInfoController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ContactInfoDto contactInfo)
        {
            try
            {
                await _httpClient.PostAsJsonAsync("contactinfo/save", contactInfo);
                return RedirectToAction(nameof(Index), new { ContactUUID = contactInfo.ContactUUID });
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            try
            {
                await _httpClient.DeleteAsync("contactinfo/remove?uuid=" + uuid.ToString());
                return RedirectToAction(nameof(Index), new { ContactUUID = HttpContext.Request.Query["ContactUUID"] });
            }
            catch
            {
                return View();
            }
        }
    }
}
