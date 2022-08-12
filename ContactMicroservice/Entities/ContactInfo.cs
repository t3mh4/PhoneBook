using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable
namespace ContactMicroservice.Entities
{
    [Table("ContactInfo")]
    public class ContactInfo
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UUID { get; set; }

        [StringLength(15)]
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string EMail { get; set; }
        [Required]
        public string Location { get; set; }
        public virtual Contact Contact { get; set; }
    }
}
