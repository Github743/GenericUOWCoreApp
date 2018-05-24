using System;

namespace CoreApp.Models.DataTransfer
{
    public class Employee : DtoBase
    {
        public int EmployeeId { get; set; }

        public Guid EmployeeGuid { get; set; }

        public string CompanyName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
