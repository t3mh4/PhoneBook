using PhoneBook.Dtos;

namespace ReportMicroservice.Managers
{
    public interface IReportManager
    {
        Task<List<ReportDto>> GetAll();
        Task GenerateReport();
        Task<ReportDetailDto> GetDetailsByUUID(Guid uuid);
    }
}
