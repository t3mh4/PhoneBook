using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Core.Enums
{
    enum EnumReport
    {
        [Display(Name = "Hazırlanıyor")]
        Preparing = 10,
        [Display(Name = "Tamamlandı")]
        Completed = 20
    }
}
