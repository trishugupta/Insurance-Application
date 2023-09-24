using AutoMapper;
using Insurance.Model;
using Insurance.Model.Dtos;

namespace Insurance.Profiles
{
    public class GetPolicyProfile : Profile
    {
        public GetPolicyProfile()
        {
            // Source -> Target
            CreateMap<GetPolicy, GetPolicyDto>();
        }
    }
}
