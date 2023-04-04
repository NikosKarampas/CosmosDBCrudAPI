namespace EmployeesAPI.Contracts.Requests
{
    public class UpdateEmployeeRequest
    {
        public string Id { get; set; }

        public string Department { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }
    }
}