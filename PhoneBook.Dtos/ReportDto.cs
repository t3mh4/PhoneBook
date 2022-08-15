using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Dtos
{
    public class ReportDto
    {
        public Guid UUID { get; set; }
        public DateTime ReportDate { get; set; }
        public int Status { get; set; }
        public string FullPath { get; set; }
        public string StatusName { get; set; }

    }
}
