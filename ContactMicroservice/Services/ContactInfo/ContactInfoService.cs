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
    }
}
