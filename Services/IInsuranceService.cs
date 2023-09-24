
using Insurance.Model.Dtos;

namespace Insurance.Services
{
    public interface IInsuranceService
    {
        Task<PolicyReadDto> CreatePolicy(CreatePolicyDto createPolicyDto);
        Task<CustomerReadDto> CreateCustomer(CreateCustomerDto createCustomerDto);
        Task<List<PolicyReadDto>> GetPolicies();
        Task<bool> DeletePolicy(string policycode);
        Task<PolicyReadDto> EditPolicy(string policycode,CreatePolicyDto createPolicyDto);
        Task<List<GetPolicyDto>> GetPoliciesByMonth(string? region = "");
    }
}
