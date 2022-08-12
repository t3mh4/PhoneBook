using ContactMicroservice.Entities;

namespace ContactMicroservice.Managers
{
    public interface IContactManager
    {
        Task<bool> SaveAsync(Contact contact);
        Task<bool> RemoveAsync(Guid uuid);
        Task<IList<Contact>> GetAll();
    }
}
