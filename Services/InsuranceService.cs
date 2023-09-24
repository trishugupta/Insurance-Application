using Insurance.Model.Dtos;
using Insurance.Repository;
using AutoMapper;
using Insurance.Model;
using AuthApi.Exceptions;
using System.Net.Mail;

namespace Insurance.Services
{
    public class InsuranceService : IInsuranceService
    {
        private readonly ILogger<InsuranceService> _logger;
        private readonly IMapper _mapper;
        private readonly IPolicyRepository _policyRepository;

        public InsuranceService(ILogger<InsuranceService> logger,
            IMapper mapper,
            IPolicyRepository policyRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _policyRepository = policyRepository;
        }

        public async Task<List<PolicyReadDto>> GetPolicies() {
            var policy = await _policyRepository.GetAllPolicies();
           var mappedDetails = _mapper.Map<List<Policy>, List<PolicyReadDto>>(policy);
            return mappedDetails;
        }
        public async Task<List<GetPolicyDto>> GetPoliciesByMonth(string? region = "")
        {
            var policy = await _policyRepository.GetPoliciesByMonth(region);
            var mappedDetails = _mapper.Map<List<GetPolicy>, List<GetPolicyDto>>(policy);
            return mappedDetails;
        }

        public async Task<bool> DeletePolicy(string policycode)
        {
            var policy = await _policyRepository.DeletePolicy(policycode);
            return policy;
        }

        public async Task<PolicyReadDto> CreatePolicy(CreatePolicyDto createPolicyDto)
        {
            // request validations
            // 1. PolicyCode is mandatory.
            // 2. check if the policy already exists.

            if (string.IsNullOrEmpty(createPolicyDto.PolicyCode))
            {
                throw new RequestValidationException("PolicyCode cannot be empty");
            }


            Policy? policy = await _policyRepository.GetPolicyByCode(createPolicyDto.PolicyCode);
            Policy input = new Policy
            {
                PolicyCode = createPolicyDto.PolicyCode,
                PurchaseDate = createPolicyDto.PurchaseDate,
                Fuel = createPolicyDto.Fuel,
                VehicleSegment = createPolicyDto.VehicleSegment,
                Premium = createPolicyDto.Premium,
                bodily_injury_liability = createPolicyDto.bodily_injury_liability,
                personal_injury_protection = createPolicyDto.personal_injury_protection,
                property_damage_liability = createPolicyDto.property_damage_liability,
                collision = createPolicyDto.collision,
                comprehensive = createPolicyDto.comprehensive
            };
            
            if (policy == null)
            {
                // call the repository to create the policy which returns PolicyReadDto.
                policy = await _policyRepository.CreatePolicy(input);

            }

            // map the policy object to policy dto object
            var mappedUser = _mapper.Map<Policy, PolicyReadDto>(policy);
            return mappedUser;
        }

        public async Task<PolicyReadDto> EditPolicy(string policycode,CreatePolicyDto createPolicyDto)
        {
            // request validations
            // 3. check if the policy already exists.


            Policy? policy = await _policyRepository.GetPolicyByCode(createPolicyDto.PolicyCode);
            Policy input = new Policy
            {
                PolicyCode = createPolicyDto.PolicyCode,
                Fuel = createPolicyDto.Fuel,
                VehicleSegment = createPolicyDto.VehicleSegment,
                Premium = createPolicyDto.Premium,
                bodily_injury_liability = createPolicyDto.bodily_injury_liability,
                personal_injury_protection = createPolicyDto.personal_injury_protection,
                property_damage_liability = createPolicyDto.property_damage_liability,
                collision = createPolicyDto.collision,
                comprehensive = createPolicyDto.comprehensive
            };

            if (policy != null)
            {
                // call the repository to update the policy which returns PolicyReadDto.
                policy = await _policyRepository.UpdatePolicy(policycode,input);

            }

            // map the policy object to policy dto object
            var mappedUser = _mapper.Map<Policy, PolicyReadDto>(policy);
            return mappedUser;
        }


        public async Task<CustomerReadDto> CreateCustomer(CreateCustomerDto createCustomerDto)
        {
            // request validations
            // 1. Username is mandatory.
            // 2. Username should be an email.
            // 3. check if the customer already exists.

            if (string.IsNullOrEmpty(createCustomerDto.UserName))
            {
                throw new RequestValidationException("Username cannot be empty");
            }

            try
            {
                var emailAddress = new MailAddress(createCustomerDto.UserName);
            }
            catch
            {
                throw new RequestValidationException($"Username {createCustomerDto.UserName} is an invalid email address");
            }


            Customer? customer = await _policyRepository.GetCustomerByUsername(createCustomerDto.UserName);
            Customer input = new Customer
            {
                UserName = createCustomerDto.UserName,
                FirstName = createCustomerDto.FirstName,
                LastName = createCustomerDto.LastName,
                Gender = createCustomerDto.Gender,
                Incomegroup = createCustomerDto.Incomegroup,
                Region = createCustomerDto.Region,
                Maritalstatus = createCustomerDto.Maritalstatus
            };

            Policy? policy = await _policyRepository.GetPolicyByCode(createCustomerDto.PolicyCode);
            if (customer == null)
            {
                // call the repository to create the customer which returns CustomerReadDto.
                customer = await _policyRepository.CreateCustomer(input);
                //Add Mapping of PolicyId with CustomerId
                if (policy != null)
                {
                    var result = await _policyRepository.CreatePolicyCustomerMapping(policy.PolicyId, customer.CustomerId);
                }

            }
            else
            {
                if (policy != null)
                {
                    var result = await _policyRepository.CreatePolicyCustomerMapping(policy.PolicyId, customer.CustomerId);
                }
            }

            // map the customer object to customer dto object
            var mappedUser = _mapper.Map<Customer, CustomerReadDto>(customer);
            return mappedUser;
        }

    }
}
