using ContactMicroservice.DBContext;
using ContactMicroservice.Entities;

namespace ContactMicroservice.Repositories
{
    public class ConctactRepository : Repository<Contact>, IContactRepository
    {
        public ConctactRepository(PhoneBookContext dbContext) : base(dbContext)
        {
        }
    }
}
