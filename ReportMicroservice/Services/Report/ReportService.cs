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
                StatusName = ((EnumReport.Status)s.Status).GetDisplayName(),
                Status = s.Status
            }).ToListAsync();
        }

        public async Task<ReportDetailDto> GetDetailsByUUID(Guid uuid)
        {
            return await _dbContext.Reports.AsNoTracking().Where(r => r.UUID == uuid)
                .Select(s => new ReportDetailDto
            {
                FileName = Path.GetFileName(s.FullPath),
                CreatedDate = s.CreatedDate
            }).FirstOrDefaultAsync()??new ReportDetailDto();
        }
    }
}
