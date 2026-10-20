
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystemm.Models
{
    public class Employee
    {
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public string? EmployeeCode { get; set; }
        [Required]
        [StringLength(50)]
        public string? EmployeeName { get; set; }
        [Required]
        [MaxLength(13)]
        public string? EmployeePhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string? Email {get; set; }
        [Required]
        [MaxLength(10)]
        public string? Gender { get; set; }
        public DateOnly DateOfBirth { get; set; }
        [Required]
        [Range(0, 999999)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Salary {get; set; }
        [Required]
        [MaxLength(100)]
        public string? Address { get; set; }
        [Required]
        [MaxLength(40)]
        public string? DepartmentName { get; set; }
    }
}
