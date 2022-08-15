using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Dtos;
using PhoneBookWebUI.Helper;

namespace PhoneBookWebUI.Controllers
{
    public class ContactController : BaseContoller
    {
        public async Task<ActionResult> Index()
        {
            return View(await _httpClient.GetFromJsonAsync<List<ContactDto>>("contact/getall"));
        }      

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ContactDto contact)
        {
            try
            {
                await _httpClient.PostAsJsonAsync("contact/save", contact);
                return RedirectToAction(nameof(Index));
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
                await _httpClient.DeleteAsync("contact/remove?uuid=" + uuid.ToString());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            _httpClient.Dispose();
            base.Dispose(disposing);
        }
    }
}
