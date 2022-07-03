using HR.DataAccess.Entities;

namespace HR.Api.DataAccess.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }

        public Address address { get; set; }
    }
}
