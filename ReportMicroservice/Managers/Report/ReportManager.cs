using PhoneBook.Dtos;
using ReportMicroservice.Services;

namespace ReportMicroservice.Managers
{
    public class ReportManager : IReportManager
    {
        private readonly IReportService _service;
        public ReportManager(IReportService service)
        {
            _service = service;
        }

        public async Task<List<ReportDto>> GetAll()
        {
            return await _service.GetAll();
        }
    }
}
