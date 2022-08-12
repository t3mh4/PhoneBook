using ContactMicroservice.DBContext;
using ContactMicroservice.Entities;

namespace ContactMicroservice.Repositories
{
    public class ContactInfoRepository : Repository<ContactInfo>, IContactInfoRepository
    {
        public ContactInfoRepository(PhoneBookContext dbContext) : base(dbContext)
        {
        }
    }
}
