using Insurance.Model;

namespace Insurance.Repository
{
    public interface IPolicyRepository
    {
        Task<Policy> CreatePolicy(Policy policy);
        Task<Policy> UpdatePolicy(string policycode,Policy policy);
        Task<List<Policy>> GetAllPolicies();
        Task<Policy?> GetPolicyByCode(string policycode);
        Task<Customer> CreateCustomer(Customer customer);
        Task<Customer> GetCustomerByUsername(string Username);
        Task<bool> CreatePolicyCustomerMapping(long PolicyId, long CustomerId);
        Task<bool> DeletePolicy(string policycode);
        Task<List<GetPolicy>> GetPoliciesByMonth(string? region = "");
    }
}
