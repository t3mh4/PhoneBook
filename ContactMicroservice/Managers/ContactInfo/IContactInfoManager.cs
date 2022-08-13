using ContactMicroservice.Entities;
using PhoneBook.Dtos;

namespace ContactMicroservice.Managers
{
    public interface IContactInfoManager
    {
        Task<bool> SaveAsync(ContactInfoDto contactInfoDto);
        Task<bool> RemoveAsync(Guid uuid);
        Task<List<ContactInfoDto>> GetAllByContactUUID(Guid contactUUID);
    }
}
