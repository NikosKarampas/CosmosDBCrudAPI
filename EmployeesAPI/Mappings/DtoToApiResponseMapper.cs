using EmployeesAPI.Contracts.Data;
using EmployeesAPI.Contracts.Responses;

namespace EmployeesAPI.Mappings
{
    public static class DtoToApiResponseMapper
    {
        public static EmployeeResponse ToEmployeeResponse(this EmployeeDto employeeDto)
        {
            return new EmployeeResponse
            {
                Id = employeeDto.Id,
                Department = employeeDto.Department,
                Name = employeeDto.Name,
                Country = employeeDto.Country
            };
        }
    }
}