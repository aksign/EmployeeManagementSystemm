
using EmployeeManagementSystemm.Data;
using EmployeeManagementSystemm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystemm.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.username == model.Username);

            if (user == null ||
                !BCrypt.Net.BCrypt.Verify(model.Password, user.password))
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View(model);
            }

            HttpContext.Session.SetString("Username", user.username);

            return RedirectToAction("Index", "Dashboard");
        }
    }
}
