using ContactMicroservice.DBContext;
using ContactMicroservice.Entities;
using ContactMicroservice.Repositories;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Dtos;

namespace ContactMicroservice.Services
{
    public class ContactService : Repository<Contact>, IContactService
    {
        public ContactService(PhoneBookContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<ContactDto>> GetAll()
        {
            return await (from c in _dbContext.Contacts
                          select new ContactDto
                          {
                              UUID = c.UUID,
                              Name = c.Name,
                              Surname = c.Surname,
                              Company = c.Company
                          }).AsNoTracking().ToListAsync();
        }
    }
}
