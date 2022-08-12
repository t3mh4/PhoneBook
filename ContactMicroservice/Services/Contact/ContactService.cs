using ContactMicroservice.DBContext;
using ContactMicroservice.Entities;
using ContactMicroservice.Repositories;

namespace ContactMicroservice.Services
{
    public class ContactService : Repository<Contact>, IContactService
    {
        public ContactService(PhoneBookContext dbContext) : base(dbContext)
        {
        }
    }
}
