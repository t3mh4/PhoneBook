using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReportMicroservice.Entities
{
    [Table("Report")]
    public class Report
    {
        [Key]
        public Guid UUID { get; set; }
        public DateTime ReportDate { get; set; }
        public int Status { get; set; }
        public string FullPath { get; set; }
    }
}
