using Microsoft.AspNetCore.Mvc;

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
                BaseAddress = new Uri("http://localhost:17000")
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
