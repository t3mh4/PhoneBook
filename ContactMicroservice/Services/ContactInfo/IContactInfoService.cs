using ContactMicroservice.Entities;
using ContactMicroservice.Repositories;

namespace ContactMicroservice.Services
{
    public interface IContactInfoService : IRepository<ContactInfo>
    {
        Task<List<ContactInfo>> GetAllByContactUUID(Guid contactUUID);
    }
}
