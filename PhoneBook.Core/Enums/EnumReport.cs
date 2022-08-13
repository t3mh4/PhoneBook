using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Core.Enums
{
    public class EnumReport
    {
        public enum Status
        {
            [Display(Name = "Hazırlanıyor")]
            Preparing = 10,
            [Display(Name = "Tamamlandı")]
            Completed = 20
        }
    }
}
