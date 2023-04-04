using EmployeesAPI.Contracts.Data;

namespace EmployeesAPI.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public Task<bool> CreateAsync(EmployeeDto employeeDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(EmployeeDto employeeDto)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeDto?> GetByIdAsync(string id, string partitionKey)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(EmployeeDto employeeDto)
        {
            throw new NotImplementedException();
        }
    }
}