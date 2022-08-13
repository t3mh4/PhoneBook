using ReportMicroservice.DBContext;
using ReportMicroservice.Entities;
using ReportMicroservice.Repositories;

namespace ReportMicroservice.Services
{
    public class ReportService : Repository<Report>, IReportService
    {
        public ReportService(PhoneBookContext dbContext) : base(dbContext)
        {
        }
    }
}
