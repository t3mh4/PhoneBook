using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        public Guid ContactUUID { get; set; }

        [JsonIgnore]
        public virtual Contact Contact { get; set; }
    }
}
