using EmployeesAPI.Contracts.Data;
using EmployeesAPI.Contracts.Requests;

namespace EmployeesAPI.Mappings
{
    public static class UpdateApiRequestToDtoMapper
    {
        public static EmployeeDto ToEmployeeDto(this UpdateEmployeeRequest updateEmployeeRequest)
        {
            return new EmployeeDto
            {
                Id = updateEmployeeRequest.Id,
                Department = updateEmployeeRequest.Department,
                Name = updateEmployeeRequest.UpdateEmployeeRequestBody.Name,
                Country = updateEmployeeRequest.UpdateEmployeeRequestBody.Country
            };
        }
    }
}