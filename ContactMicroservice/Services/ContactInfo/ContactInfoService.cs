using ContactMicroservice.DBContext;
using ContactMicroservice.Entities;
using ContactMicroservice.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ContactMicroservice.Services
{
    public class ContactInfoService : Repository<ContactInfo>, IContactInfoService
    {
        public ContactInfoService(PhoneBookContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<ContactInfo>> GetAllByContactUUID(Guid contactUUID)
        {
            return await _dbContext.ContactInfos.Where(w => w.ContactUUID == contactUUID).ToListAsync();
        }
    }
}
