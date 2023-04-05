using EmployeesAPI.Contracts.Data;
using EmployeesAPI.Contracts.Requests;
using EmployeesAPI.Contracts.Responses;
using EmployeesAPI.Mappings;
using EmployeesAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        
        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult<EmployeeResponse>> Create([FromBody] EmployeeRequest employeeRequest)
        {
            var employeeDto = employeeRequest.ToEmployeeDto();

            await _employeeRepository.CreateAsync(employeeDto);

            var employeeResponse = employeeDto.ToEmployeeResponse();

            return CreatedAtAction(nameof(Get), new { id = employeeResponse.Id, partitionKey = employeeResponse.Department }, employeeResponse);
        }

        [HttpGet("{id}/{partitionKey}")]        
        public async Task<ActionResult<EmployeeResponse>> Get([FromRoute] string id, [FromRoute] string partitionKey)
        {
            EmployeeDto? employeeDto = await _employeeRepository.GetByIdAsync(id, partitionKey);

            if (employeeDto is null)
                return NotFound();

            return Ok(employeeDto.ToEmployeeResponse());
        }

        [HttpPut("{id:guid}/{partitionKey}")]        
        public async Task<ActionResult<EmployeeResponse>> Update([FromMultiSource] UpdateEmployeeRequest updateEmployeeRequest)
        {
            var existingEmployee = await _employeeRepository.GetByIdAsync(updateEmployeeRequest.Id, 
                updateEmployeeRequest.Department);
            
            if (existingEmployee is null)
                return NotFound();

            var updateEmployeeDto = updateEmployeeRequest.ToEmployeeDto();

            await _employeeRepository.UpdateAsync(updateEmployeeDto);

            return Ok(updateEmployeeDto.ToEmployeeResponse());
        }
    }
}