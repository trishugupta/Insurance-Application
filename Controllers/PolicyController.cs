using AuthApi.Exceptions;
using Insurance.Model.Dtos;
using Insurance.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Insurance.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PolicyController : ControllerBase
    {
        private readonly ILogger<PolicyController> _logger;
        private readonly IInsuranceService _insuranceService;

        private const string SUCCESS_CODE = "SUCCESS";
        private const string INTERNAL_SERVER_ERROR_CODE = "INTERNAL_SERVER_ERROR";
        private const string UNAUTHORIZED_ERROR_CODE = "UNAUTHORIZED";
        private const string BAD_REQUEST_ERROR_CODE = "VALIDATION_ERROR";

        public PolicyController(ILogger<PolicyController> logger, IInsuranceService insuranceService)
        {
            _logger = logger;
            _insuranceService = insuranceService;
        }

        [HttpGet("GetPolicies")]
        public async Task<ActionResult> GetPolicies() {
            var response = new ResponseDto<List<PolicyReadDto>>();

            try
            {
                //Get All the policies from the database
                var policy = await _insuranceService.GetPolicies();


                response.Code = SUCCESS_CODE;
                response.Data = policy;
                return Ok(response);
            }
            catch (RequestValidationException ex)
            {
                _logger.LogError("Request Validation Error in GetPolicies: {errMsg}", ex.Message);
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                response.Code = BAD_REQUEST_ERROR_CODE;
                response.Message = "One or more validation errors occurred";
                response.Error = ex.Message;
                return StatusCode((int)HttpStatusCode.BadRequest, response);
            }
            catch (DbOperationException ex)
            {
                _logger.LogError("Db Operation Error in GetPolicies: {errMsg}", ex.Message);
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                response.Code = INTERNAL_SERVER_ERROR_CODE;
                response.Message = "Something went wrong!";
                response.Error = ex.Message;
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception in GetPolicies: {errMsg}", ex.Message);
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                response.Code = INTERNAL_SERVER_ERROR_CODE;
                response.Message = "Something went wrong!";
                response.Error = ex.Message;
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
        }

        [HttpGet("GetPoliciesByMonth")]
        public async Task<ActionResult> GetPoliciesByMonth(string? region = "")
        {
            var response = new ResponseDto<List<GetPolicyDto>>();

            try
            {
                if (string.IsNullOrWhiteSpace(region))
                {
                    region = null;
                }

                //Fetch the no of policies bought each month
                var policy = await _insuranceService.GetPoliciesByMonth(region);


                response.Code = SUCCESS_CODE;
                response.Data = policy;
                return Ok(response);
            }
            catch (RequestValidationException ex)
            {
                _logger.LogError("Request Validation Error in GetPoliciesByMonth: {errMsg}", ex.Message);
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                response.Code = BAD_REQUEST_ERROR_CODE;
                response.Message = "One or more validation errors occurred";
                response.Error = ex.Message;
                return StatusCode((int)HttpStatusCode.BadRequest, response);
            }
            catch (DbOperationException ex)
            {
                _logger.LogError("Db Operation Error in GetPoliciesByMonth: {errMsg}", ex.Message);
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                response.Code = INTERNAL_SERVER_ERROR_CODE;
                response.Message = "Something went wrong!";
                response.Error = ex.Message;
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception in GetPoliciesByMonth: {errMsg}", ex.Message);
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                response.Code = INTERNAL_SERVER_ERROR_CODE;
                response.Message = "Something went wrong!";
                response.Error = ex.Message;
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
        }


        [HttpDelete("deletepolicy/{policycode}")]
        public async Task<ActionResult> DeletePolicy(string policycode)
        {
            var response = new ResponseDto<bool>();

            try
            {
                //Delete Policy
                var policy = await _insuranceService.DeletePolicy(policycode);
                response.Code = SUCCESS_CODE;
                response.Data = true;
                return Ok(response);
            }
            catch (RequestValidationException ex)
            {
                _logger.LogError("Request Validation Error in DeletePolicy: {errMsg}", ex.Message);
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                response.Code = BAD_REQUEST_ERROR_CODE;
                response.Message = "One or more validation errors occurred";
                response.Error = ex.Message;
                return StatusCode((int)HttpStatusCode.BadRequest, response);
            }
            catch (DbOperationException ex)
            {
                _logger.LogError("Db Operation Error in Delete Policy: {errMsg}", ex.Message);
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                response.Code = INTERNAL_SERVER_ERROR_CODE;
                response.Message = "Something went wrong!";
                response.Error = ex.Message;
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception in DeletePolicy: {errMsg}", ex.Message);
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                response.Code = INTERNAL_SERVER_ERROR_CODE;
                response.Message = "Something went wrong!";
                response.Error = ex.Message;
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
        }



        [HttpPost("createpolicy")]
        [ProducesResponseType(typeof(ResponseDto<PolicyReadDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<string>), 400)]
        public async Task<ActionResult> CreatePolicy([FromBody] CreatePolicyDto createpolicyDto)
        {
            var response = new ResponseDto<PolicyReadDto>();

            try
            {
                //Creation of policies
                var policy = await _insuranceService.CreatePolicy(createpolicyDto);
                

                response.Code = SUCCESS_CODE;
                response.Data = policy;
                return Ok(response);
            }
            catch (RequestValidationException ex)
            {
                _logger.LogError("Request Validation Error in CreatePolicy: {errMsg}", ex.Message);
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                response.Code = BAD_REQUEST_ERROR_CODE;
                response.Message = "One or more validation errors occurred";
                response.Error = ex.Message;
                return StatusCode((int)HttpStatusCode.BadRequest, response);
            }
            catch (DbOperationException ex)
            {
                _logger.LogError("Db Operation Error in CreatePolicy: {errMsg}", ex.Message);
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                response.Code = INTERNAL_SERVER_ERROR_CODE;
                response.Message = "Something went wrong!";
                response.Error = ex.Message;
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception in CreatePolicy: {errMsg}", ex.Message);
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                response.Code = INTERNAL_SERVER_ERROR_CODE;
                response.Message = "Something went wrong!";
                response.Error = ex.Message;
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
        }

        [HttpPut("editpolicy/{policycode}")]
        [ProducesResponseType(typeof(ResponseDto<PolicyReadDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<string>), 400)]
        public async Task<ActionResult> EditPolicy(string policycode, [FromBody] CreatePolicyDto createpolicyDto)
        {
            var response = new ResponseDto<PolicyReadDto>();

            try
            {
                //Update existing policies
                var policy = await _insuranceService.EditPolicy(policycode,createpolicyDto);


                response.Code = SUCCESS_CODE;
                response.Data = policy;
                return Ok(response);
            }
            catch (RequestValidationException ex)
            {
                _logger.LogError("Request Validation Error in EditPolicy: {errMsg}", ex.Message);
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                response.Code = BAD_REQUEST_ERROR_CODE;
                response.Message = "One or more validation errors occurred";
                response.Error = ex.Message;
                return StatusCode((int)HttpStatusCode.BadRequest, response);
            }
            catch (DbOperationException ex)
            {
                _logger.LogError("Db Operation Error in EditPolicy: {errMsg}", ex.Message);
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                response.Code = INTERNAL_SERVER_ERROR_CODE;
                response.Message = "Something went wrong!";
                response.Error = ex.Message;
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception in EditPolicy: {errMsg}", ex.Message);
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                response.Code = INTERNAL_SERVER_ERROR_CODE;
                response.Message = "Something went wrong!";
                response.Error = ex.Message;
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
        }


        [HttpPost("createCustomer")]
        [ProducesResponseType(typeof(ResponseDto<CustomerReadDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<string>), 400)]
        public async Task<ActionResult> CreateCustomer([FromBody] CreateCustomerDto createCustomerDto)
        {
            var response = new ResponseDto<CustomerReadDto>();

            try
            {
                //Creation of Customers
                var customer = await _insuranceService.CreateCustomer(createCustomerDto);


                response.Code = SUCCESS_CODE;
                response.Data = customer;
                return Ok(response);
            }
            catch (RequestValidationException ex)
            {
                _logger.LogError("Request Validation Error in CreateCustomer: {errMsg}", ex.Message);
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                response.Code = BAD_REQUEST_ERROR_CODE;
                response.Message = "One or more validation errors occurred";
                response.Error = ex.Message;
                return StatusCode((int)HttpStatusCode.BadRequest, response);
            }
            catch (DbOperationException ex)
            {
                _logger.LogError("Db Operation Error in Create Customer: {errMsg}", ex.Message);
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                response.Code = INTERNAL_SERVER_ERROR_CODE;
                response.Message = "Something went wrong!";
                response.Error = ex.Message;
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception in CreateCustomer: {errMsg}", ex.Message);
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                response.Code = INTERNAL_SERVER_ERROR_CODE;
                response.Message = "Something went wrong!";
                response.Error = ex.Message;
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
        }

    }
}