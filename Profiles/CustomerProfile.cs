using AutoMapper;
using Insurance.Model;
using Insurance.Model.Dtos;

namespace Insurance.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            // Source -> Target
            CreateMap<Customer, CustomerReadDto>();
        }
    }
}
