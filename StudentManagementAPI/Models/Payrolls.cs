using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementAPI.Models
{
    public class Payrolls
    {
        [Key]
        public int PayrollID { get; set; }

        [Required]
        [MaxLength(100)]
        public string  PaymentMethod { get; set; }

        [Required]
        [MaxLength(100)]
        public string BankAccount { get; set; }

        [Required]
        [MaxLength(100)]
        public string BankName { get; set; }

        public DateTime PayrollDate { get; set; }


        public int Amount { get; set; }

        
        [MaxLength(100)]
        public string Remarks { get; set; }


    }
}

