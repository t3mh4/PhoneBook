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
                          orderby c.Name,c.Surname
                          select new ContactDto
                          {
                              UUID = c.UUID,
                              Name = c.Name,
                              Surname = c.Surname,
                              Company = c.Company
                          }).AsNoTracking().ToListAsync();
        }

        public override async Task RemoveAsync(Guid uuid)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var contactInfos = _dbContext.ContactInfos.Where(w => w.ContactUUID == uuid);
                _dbContext.ContactInfos.RemoveRange(contactInfos);
                var contact = await _dbContext.Contacts.FirstOrDefaultAsync(c => c.UUID == uuid);
                _dbContext.Contacts.Remove(contact);
                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                transaction.RollbackAsync();
            }
        }
        
    }
}
