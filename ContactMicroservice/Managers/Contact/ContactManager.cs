using ContactMicroservice.Entities;
using ContactMicroservice.Services;

namespace ContactMicroservice.Managers
{
    public class ContactManager : IContactManager
    {
        private readonly IContactService _contactService;
        public ContactManager(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<bool> SaveAsync(Contact contact)
        {
            if (contact.UUID == Guid.Empty)
                await _contactService.AddAsync(contact);
            else
                await _contactService.UpdateAsync(contact);
            return await _contactService.SaveAsync();
        }

        public async Task<bool> RemoveAsync(Guid uuid)
        {
            await _contactService.RemoveAsync(uuid);
            return await _contactService.SaveAsync();
        }

        public async Task<IList<Contact>> GetAll()
        {
            return await _contactService.GetAllAsync();
        } 
    }
}
