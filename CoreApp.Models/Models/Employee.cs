using CoreApp.Models.Models.Abstract;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreApp.Models.Models
{
    public class Employee: BaseEntityModel
    {
        [Required, Key]
        public int EmployeeId { get; set; }

        [Required]
        public Guid EmployeeGuid { get; set; }

        [MaxLength(50)]
        public string CompanyName { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
    }
}
