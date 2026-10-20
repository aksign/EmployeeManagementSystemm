using System.ComponentModel.DataAnnotations;
namespace EmployeeManagementSystemm.Models
{
    public class User
    {
        [Key]
        public int userid { get; set; }

        [Required]
        public string username { get; set; } = string.Empty;

        [Required]
        public string password { get; set; } = string.Empty;
    }
}
