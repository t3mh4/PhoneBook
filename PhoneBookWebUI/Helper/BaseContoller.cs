using Microsoft.AspNetCore.Mvc;
using PhoneBook.Core.Configuration;

namespace PhoneBookWebUI.Helper
{
    public class BaseContoller : Controller
    {
        private bool _isDisposed = false;
        protected readonly HttpClient _httpClient;
        public BaseContoller()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl.GatewayBaseHttpsUrl)
            };
        }

        protected override void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    _httpClient.Dispose();
                }
                _isDisposed = true;
            }
            base.Dispose(disposing);
        }
    }
}
