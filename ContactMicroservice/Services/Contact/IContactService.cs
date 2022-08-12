using ContactMicroservice.Entities;
using ContactMicroservice.Repositories;

namespace ContactMicroservice.Services
{
    public interface IContactService : IRepository<Contact>
    {
    }
}
