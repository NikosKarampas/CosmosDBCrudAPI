using EmployeesAPI.Contracts.Data;

namespace EmployeesAPI.Repositories
{
    public interface IEmployeeRepository
    {
        Task<bool> CreateAsync(EmployeeDto employeeDto);

        Task<EmployeeDto?> GetByIdAsync(string id, string partitionKey);

        Task<bool> UpdateAsync(EmployeeDto employeeDto);

        Task<bool> DeleteAsync(EmployeeDto employeeDto);
    }
}