using AuthApi.Exceptions;
using Dapper;
using Insurance.Model;
using System;
using System.Collections.Generic;
using System.Data;
namespace Insurance.Repository
{
    public class PolicyRepository : IPolicyRepository
    {
            private readonly IDbConnection _dbConnection;

            public PolicyRepository(IDbConnection dbConnection)
            {
                _dbConnection = dbConnection;
            }

            public async Task<List<Policy>> GetAllPolicies()
            {
                var result =  await _dbConnection.QueryAsync<Policy>("SELECT * FROM Policy");
              return result.ToList();
            }

        public async Task<List<GetPolicy>> GetPoliciesByMonth(string? region = "")
        {
            var procedure = "usp_GetPoliciesByMonth";
            var parameters = new
            {
                @Region = region,
            };
            var result = await _dbConnection.QueryAsync<GetPolicy>(procedure, parameters, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<Customer> GetCustomerByUsername(string Username)
        {
            var procedure = "usp_GetCustomerByUsername";
            var parameters = new
            {
                @Username = Username,
            };

            var dbResult = await _dbConnection.QueryAsync<Customer>(procedure, parameters, commandType: CommandType.StoredProcedure);
            return dbResult.FirstOrDefault();

        }

        public async Task<Policy> GetPolicyByCode(string policycode)
          {
            var procedure = "usp_GetPolicyByCode";
            var parameters = new
            {
                @PolicyCode = policycode,
            };

            var dbResult = await _dbConnection.QueryAsync<Policy>(procedure, parameters, commandType: CommandType.StoredProcedure);
            return dbResult.FirstOrDefault();
          }

        public async Task<Policy> CreatePolicy(Policy policy)
            {
                var procedure = "usp_InsertPolicy";
                var parameters = new
                {
                    @PolicyCode = policy.PolicyCode,
                    @PurchaseDate = policy.PurchaseDate,
                    @Fuel = policy.Fuel,
                    @VECHILE_SEGMENT = policy.VehicleSegment,
                    @Premium = policy.Premium,
                    @InjuryLiability = policy.bodily_injury_liability,
                    @InjuryProtection = policy.personal_injury_protection,
                    @ProperyLiability = policy.property_damage_liability,
                    @Collision = policy.collision,
                    @Comprehensive = policy.comprehensive

                };

                var policyId = await _dbConnection.ExecuteScalarAsync<Int64>(procedure, parameters, commandType: CommandType.StoredProcedure);
                if (policyId <= 0)
                {
                    throw new Exception($"Unable to Insert policy in Db");
                }

                var policies = await GetPolicyByCode(policy.PolicyCode);
                if (policies == null)
                {
                    throw new Exception($"No policy with policyCode {policy.PolicyCode} found");
                }

                return policies;
            }

            public async Task<Policy> UpdatePolicy(string policycode,Policy policy)
            {
               var procedure = "usp_UpdatePolicy";
              var parameters = new
              {
                @PolicyCode = policycode,
                @Fuel = policy.Fuel,
                @VECHILE_SEGMENT = policy.VehicleSegment,
                @Premium = policy.Premium,
                @InjuryLiability = policy.bodily_injury_liability,
                @InjuryProtection = policy.personal_injury_protection,
                @ProperyLiability = policy.property_damage_liability,
                @Collision = policy.collision,
                @Comprehensive = policy.comprehensive
              };

              var rowUpdated = await _dbConnection.ExecuteScalarAsync<Int64>(procedure, parameters, commandType: CommandType.StoredProcedure);
              var Policies = await GetPolicyByCode(policy.PolicyCode);
            if (Policies == null)
            {
                throw new DbOperationException($"No policy with policyCode {policy.PolicyCode} found");
            }

            return Policies;
        }

        public async Task<Customer> CreateCustomer(Customer customer)
        {
            var procedure = "usp_InsertCustomer";
            var parameters = new
            {
                @CustomerName = customer.UserName,
                @FirstName = customer.FirstName,
                @LastName = customer.LastName,
                @Gender = customer.Gender,
                @Incomegroup = customer.Incomegroup,
                @Region = customer.Region,
                @Maritalstatus = customer.Maritalstatus

            };

            var customerId = await _dbConnection.ExecuteScalarAsync<Int64>(procedure, parameters, commandType: CommandType.StoredProcedure);
            if (customerId <= 0)
            {
                throw new Exception($"Unable to Insert Customer in Db");
            }

            var customers = await GetCustomerByUsername(customer.UserName);
            if (customers == null)
            {
                throw new Exception($"No Customer with username {customer.UserName} found");
            }

            return customers;
        }

        public async Task<bool> CreatePolicyCustomerMapping(long PolicyId, long CustomerId)
        {

                var procedure = "usp_InsertPolicy_CustMapping";
            //var parameters = new
            //{
            //    @PolicyId = PolicyId,
            //    @CustomerId = CustomerId,
            //    @AffectedRows = 0,
            //};

            var parameters = new DynamicParameters();

            parameters.Add("@PolicyId", PolicyId);
            parameters.Add("@CustomerId", CustomerId);
            parameters.Add("@AffectedRows", dbType: DbType.Int32, direction: ParameterDirection.Output);

            var result = await _dbConnection.ExecuteAsync(procedure, parameters, commandType: CommandType.StoredProcedure);
            var affectedRows = parameters.Get<int>("@AffectedRows");
            if (affectedRows <= 0)
                {
                    throw new Exception($"Unable to Insert Mapping in Db");
                }

                return affectedRows > 0;
            
        }


        public async Task<bool> DeletePolicy(string  policycode)
            {
            var procedure = "usp_DeletePolicy";
            var parameters = new
            {
                @PolicyCode = policycode,

            };
                var affectedRows = await _dbConnection.ExecuteAsync(procedure, parameters,commandType: CommandType.StoredProcedure);
                return affectedRows > 0;
            }
        }

    
}
