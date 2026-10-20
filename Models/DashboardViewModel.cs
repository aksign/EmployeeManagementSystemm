using System.Collections.Generic;
namespace EmployeeManagementSystemm.Models
{
    public class DashboardViewModel
    {
        public int TotalEmployees { get; set; }
        public int TotalDepartments {get; set; }
        public decimal TotalSalary { get; set; }
        public List<Employee> RecentEmployees { get; set; }=new List<Employee>();
    }
}
