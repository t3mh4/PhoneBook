using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Core.Enums
{
    public class EnumReport
    {
        public enum Status
        {
            [Display(Name = "Preparing")]
            Preparing = 10,
            [Display(Name = "Completed")]
            Completed = 20
        }

        public enum Command
        {
            Generate = 10
        }
    }
}
