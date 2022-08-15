using Microsoft.EntityFrameworkCore;
using PhoneBook.Core.Enums;
using PhoneBook.Core.Extensions;
using PhoneBook.Dtos;
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

        public async Task<List<ReportDto>> GetAll()
        {
            return await _dbContext.Reports.Select(s => new ReportDto
            {
                UUID = s.UUID,
                ReportDate = s.ReportDate,
                FullPath = s.FullPath,
                Status = ((EnumReport.Status)s.Status).GetDisplayName(),
                FileName = Path.GetFileName(s.FullPath) ?? String.Empty
            }).ToListAsync();
        }
    }
}
