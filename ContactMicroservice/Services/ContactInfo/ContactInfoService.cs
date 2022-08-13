using ContactMicroservice.DBContext;
using ContactMicroservice.Entities;
using ContactMicroservice.Repositories;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Dtos;

namespace ContactMicroservice.Services
{
    public class ContactInfoService : Repository<ContactInfo>, IContactInfoService
    {
        public ContactInfoService(PhoneBookContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<ContactInfoDto>> GetAllByContactUUID(Guid contactUUID)
        {
            return await _dbContext.ContactInfos.Where(w => w.ContactUUID == contactUUID)
                .Select(s => new ContactInfoDto
                {
                    UUID = s.UUID,
                    ContactUUID = s.ContactUUID,
                    EMail = s.EMail,
                    Location = s.Location,
                    PhoneNumber = s.PhoneNumber
                }).ToListAsync();
        }

        public async Task<List<LocationReportDto>> GetLocationReport()
        {
            var query = from ci in _dbContext.ContactInfos
                        group ci by ci.Location into grp
                        select new LocationReportDto
                        {
                            Location = grp.Key,
                            PersonCount = grp.Select(c => c.ContactUUID).Distinct().Count(),
                            PhoneNumberCount = grp.Select(c => c.PhoneNumber).Count()
                        };
            return await query.AsNoTracking().ToListAsync() ?? new List<LocationReportDto>();

        }
    }
}
