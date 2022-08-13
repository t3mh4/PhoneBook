using ContactMicroservice.Entities;
using PhoneBook.Dtos;

namespace ContactMicroservice.Managers
{
    public interface IContactManager
    {
        Task<bool> SaveAsync(ContactDto contact);
        Task<bool> RemoveAsync(Guid uuid);
        Task<IList<ContactDto>> GetAll();
    }
}
