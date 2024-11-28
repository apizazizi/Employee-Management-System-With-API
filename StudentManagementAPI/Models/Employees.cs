using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementAPI.Models
{
    public class Employees
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required]
        [MaxLength(100)]
        public string EmployeeName { get; set; }

        public DateTime DOB { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }
    }
}
