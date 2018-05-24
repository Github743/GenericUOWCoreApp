using System;

namespace CoreApp.Models.ViewModels
{
    public class EmployeeViewModel : BaseViewModel
    {
        public int EmployeeId { get; set; }

        public Guid EmployeeGuid { get; set; }

        public string CompanyName { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }
    }
}
