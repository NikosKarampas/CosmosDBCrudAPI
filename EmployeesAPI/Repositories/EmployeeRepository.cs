using System.Net;
using EmployeesAPI.Contracts.Data;
using Microsoft.Azure.Cosmos;

namespace EmployeesAPI.Repositories
{    
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Container _container;

        private readonly string _databaseId = "EmployeeManagementDB";
        private readonly string _containerId = "Employees";

        public EmployeeRepository(CosmosClient cosmosClient)
        {
            _container = cosmosClient.GetContainer(_databaseId, _containerId);
        }

        public async Task<bool> CreateAsync(EmployeeDto employeeDto)
        {
            var response = await _container.CreateItemAsync<EmployeeDto>(employeeDto, new PartitionKey(employeeDto.Department));

            return response.StatusCode == HttpStatusCode.OK;
        }

        public async Task<EmployeeDto?> GetByIdAsync(string id, string partitionKey)
        {
            try
            {
                var response = await _container.ReadItemAsync<EmployeeDto>(id, new PartitionKey(partitionKey));

                return response.Resource;
            }
            catch (CosmosException cosmosExc)
            {
                if (cosmosExc.StatusCode == HttpStatusCode.NotFound)
                    return null;
                else
                    throw cosmosExc;
            }
        }

        public async Task<bool> UpdateAsync(EmployeeDto employeeDto)
        {
            var response = await _container.ReplaceItemAsync<EmployeeDto>(employeeDto, employeeDto.Id, new PartitionKey(employeeDto.Department));

            return response.StatusCode == HttpStatusCode.OK;
        }

        public async Task<bool> DeleteAsync(string id, string partitionKey)
        {
            throw new NotImplementedException();
        }        
    }
}