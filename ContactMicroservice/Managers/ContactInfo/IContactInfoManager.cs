using ContactMicroservice.Entities;

namespace ContactMicroservice.Managers
{
    public interface IContactInfoManager
    {
        Task<bool> SaveAsync(ContactInfo contactInfo);
        Task<bool> RemoveAsync(Guid uuid);
        Task<List<ContactInfo>> GetAllByContactUUID(Guid contactUUID);
    }
}
