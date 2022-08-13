using AutoMapper;
using ContactMicroservice.Entities;
using PhoneBook.Dtos;

namespace ContactMicroservice
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ContactDto, Contact>().ReverseMap();
            CreateMap<ContactInfoDto, ContactInfo>().ReverseMap();
        }
    }
}
