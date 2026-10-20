using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementSystemm.Data;
using EmployeeManagementSystemm.Models;

namespace EmployeeManagementSystemm.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = new DashboardViewModel
            {
                TotalEmployees = await _context.Employees.CountAsync(),

                TotalDepartments = await _context.Employees
                    .Where(e => e.DepartmentName != null)
                    .Select(e => e.DepartmentName)
                    .Distinct()
                    .CountAsync(),

                TotalSalary = await _context.Employees
                    .SumAsync(e => (decimal?)e.Salary) ?? 0,

                RecentEmployees = await _context.Employees
                    .OrderByDescending(e => e.EmployeeId)
                    .Take(5)
                    .ToListAsync()
            };

            return View(model);
        }
    }
}