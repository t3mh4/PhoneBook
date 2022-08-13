using AutoMapper;
using ContactMicroservice.Entities;
using ContactMicroservice.Services;
using PhoneBook.Dtos;

namespace ContactMicroservice.Managers
{
    public class ContactManager : IContactManager
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        public ContactManager(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        public async Task<bool> SaveAsync(ContactDto contactDto)
        {
            var contact = _mapper.Map<Contact>(contactDto);
            if (contact.UUID == Guid.Empty)
                await _contactService.AddAsync(contact);
            else
                await _contactService.UpdateAsync(contact);
            return await _contactService.SaveAsync();
        }

        public async Task<bool> RemoveAsync(Guid uuid)
        {
            var contact =await _contactService.GetAsync(g => g.UUID == uuid);
            await _contactService.RemoveAsync(contact);
            return await _contactService.SaveAsync();
        }

        public async Task<IList<ContactDto>> GetAll()
        {
            return await _contactService.GetAll();
        } 
    }
}
