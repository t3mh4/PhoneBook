using PhoneBook.Dtos;

namespace ReportMicroservice.Managers
{
    public interface IReportManager
    {
        Task<List<ReportDto>> GetAll();
    }
}
