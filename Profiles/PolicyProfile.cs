using AutoMapper;
using Insurance.Model;
using Insurance.Model.Dtos;

namespace Insurance.Profiles
{
    public class PolicyProfile : Profile
    {
        public PolicyProfile()
        {
            // Source -> Target
            CreateMap<Policy, PolicyReadDto>();
        }
    }
}
