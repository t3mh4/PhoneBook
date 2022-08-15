using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.Configuration
{
    public class BaseUrl
    {
        private BaseUrl() { }

        public const string ContactMsBaseHttpUrl= "http://localhost:15000";
        public const string ContactMsBaseHttpsUrl = "https://localhost:15001";
        public const string ReportMsBaseHttpUrl= "http://localhost:16000";
        public const string ReportMsBaseHttpsUrl = "https://localhost:16001";
        public const string GatewayBaseHttpUrl= "http://localhost:17000";
        public const string GatewayBaseHttpsUrl = "https://localhost:17001";
    }
}
