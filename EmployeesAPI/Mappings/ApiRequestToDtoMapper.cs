using EmployeesAPI.Contracts.Data;
using EmployeesAPI.Contracts.Requests;

namespace EmployeesAPI.Mappings
{
    public static class ApiRequestToDtoMapper
    {
        public static EmployeeDto ToEmployeeDto(this EmployeeRequest employeeRequest)
        {
            return new EmployeeDto
            {
                Id = Guid.NewGuid().ToString(),
                Department = employeeRequest.Department,
                Name = employeeRequest.Name,
                Country = employeeRequest.Country
            };
        }
    }
}