using ContactMicroservice.Entities;
using ContactMicroservice.Repositories;
using PhoneBook.Dtos;

namespace ContactMicroservice.Services
{
    public interface IContactInfoService : IRepository<ContactInfo>
    {
        Task<List<ContactInfoDto>> GetAllByContactUUID(Guid contactUUID);
        Task<List<LocationReportDto>> GetLocationReport();
    }
}
