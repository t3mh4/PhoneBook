using ContactMicroservice.Entities;
using ContactMicroservice.Repositories;
using PhoneBook.Dtos;

namespace ContactMicroservice.Services
{
    public interface IContactService : IRepository<Contact>
    {
        Task<List<ContactDto>> GetAll();
    }
}
