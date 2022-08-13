using PhoneBook.Dtos;
using ReportMicroservice.Entities;
using ReportMicroservice.Repositories;

namespace ReportMicroservice.Services
{
    public interface IReportService : IRepository<Report>
    {
        Task<List<ReportDto>> GetAll();
    }
}
