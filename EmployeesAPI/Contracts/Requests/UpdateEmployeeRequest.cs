using Microsoft.AspNetCore.Mvc;

namespace EmployeesAPI.Contracts.Requests
{
    public class UpdateEmployeeRequest
    {        
        [FromRoute(Name = "id")] public string Id { get; set; }

        [FromRoute(Name = "partitionKey")] public string Department { get; set; }

        [FromBody] public UpdateEmployeeRequestBody UpdateEmployeeRequestBody { get; set; }        
    }

    public class UpdateEmployeeRequestBody
    {
        public string Name { get; set; }

        public string Country { get; set; }
    }
}