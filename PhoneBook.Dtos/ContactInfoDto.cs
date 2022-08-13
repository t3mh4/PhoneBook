using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Dtos
{
    public class ContactInfoDto
    {
        public Guid UUID { get; set; }
        public Guid ContactUUID { get; set; }
        public string PhoneNumber { get; set; }
        public string EMail { get; set; }
        public string Location { get; set; }
    }
}
