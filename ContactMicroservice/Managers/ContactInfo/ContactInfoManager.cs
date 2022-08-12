using ContactMicroservice.Entities;
using ContactMicroservice.Services;

namespace ContactMicroservice.Managers
{
    public class ContactInfoManager: IContactInfoManager
    {
        private readonly IContactInfoService _contactInfoService;
        public ContactInfoManager(IContactInfoService contactInfoService)
        {
            _contactInfoService = contactInfoService;
        }

        public async Task<List<ContactInfo>> GetAllByContactUUID(Guid contactUUID)
        {
            return await _contactInfoService.GetAllByContactUUID(contactUUID);
        }

        public async Task<bool> RemoveAsync(Guid uuid)
        {
            await _contactInfoService.RemoveAsync(uuid);
            return await _contactInfoService.SaveAsync();
        }

        public async Task<bool> SaveAsync(ContactInfo contactInfo)
        {
            if (contactInfo.UUID == Guid.Empty)
                await _contactInfoService.AddAsync(contactInfo);
            else
                await _contactInfoService.UpdateAsync(contactInfo);
            return await _contactInfoService.SaveAsync();
        }


    }
}
