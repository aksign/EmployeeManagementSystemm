using EmployeeManagementSystemm.Data;
using EmployeeManagementSystemm.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystemm.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext cont)
        {
            _context= cont;
        }
        public IActionResult Index(string search)
        {
            var employees = _context.Employees.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                employees = employees.Where(x =>x.EmployeeName !=null && x.EmployeeName.Contains(search));
            }

            return View(employees.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee e)
        {
            _context.Employees.Add(e);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int emp)
        {
            Employee? em=_context.Employees.FirstOrDefault(x=>x.EmployeeId==emp);
            return View(em);
        }
        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Update(emp);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            

            return View(emp); 
        }
        public IActionResult Details(int id)
        {
            var emp = _context.Employees.FirstOrDefault(item => item.EmployeeId == id);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }
        public IActionResult Delete(int id)
        {
            var emp = _context.Employees.FirstOrDefault(x => x.EmployeeId == id);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }
        [HttpPost]
        public IActionResult Delete(Employee em)
        {
            var emp = _context.Employees.FirstOrDefault(item => item.EmployeeId == em.EmployeeId);
            if (emp == null)
            {
                return NotFound();
            }
                _context.Employees.Remove(emp);
                _context.SaveChanges();
                return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Home()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult Services()
        {
            return View();
        }
    }
}
 