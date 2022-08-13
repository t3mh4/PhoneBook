using AutoMapper;
using ContactMicroservice.Entities;
using ContactMicroservice.Services;
using PhoneBook.Dtos;

namespace ContactMicroservice.Managers
{
    public class ContactInfoManager: IContactInfoManager
    {
        private readonly IContactInfoService _contactInfoService;
        private readonly IMapper _mapper;
        public ContactInfoManager(IContactInfoService contactInfoService,IMapper mapper)
        {
            _contactInfoService = contactInfoService;
            _mapper = mapper;
        }

        public async Task<List<ContactInfoDto>> GetAllByContactUUID(Guid contactUUID)
        {
            return await _contactInfoService.GetAllByContactUUID(contactUUID);
        }

        public async Task<List<LocationReportDto>> GetLocationReport()
        {
            return await _contactInfoService.GetLocationReport();
        }

        public async Task<bool> RemoveAsync(Guid uuid)
        {
            await _contactInfoService.RemoveAsync(uuid);
            return await _contactInfoService.SaveAsync();
        }

        public async Task<bool> SaveAsync(ContactInfoDto contactInfoDto)
        {
            var contactInfo = _mapper.Map<ContactInfo>(contactInfoDto);
            if (contactInfo.UUID == Guid.Empty)
                await _contactInfoService.AddAsync(contactInfo);
            else
                await _contactInfoService.UpdateAsync(contactInfo);
            return await _contactInfoService.SaveAsync();
        }


    }
}
