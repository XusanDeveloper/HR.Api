﻿namespace HR.Api.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }

        public int AddressId { get; set; }
    }
}
