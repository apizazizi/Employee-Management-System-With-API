using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Controllers
{
    [Route("[controller]")]
    public class EmployeesController : Controller
    {
        private readonly EmployeeManagementContext _context;

        public EmployeesController(EmployeeManagementContext context)
        {
            _context = context;
        }

        // GET: Employees
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = await _context.Employees.ToListAsync();
            return View(employees); // Returns the list view of employees
        }

        // GET: Employees/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee); // Returns the details view of a specific employee
        }

        // GET: Employees/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View(); // Returns the view for creating a new employee
        }

        // POST: Employees/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employees employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirects to the employee list
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee); // Returns the edit view for a specific employee
        }

        // POST: Employees/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Employees employee)
        {
            if (id != employee.EmployeeID)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index)); // Redirects to the employee list
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee); // Returns the delete confirmation view
        }

        // POST: Employees/Delete/5
        [HttpPost("Delete/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index)); // Redirects to the employee list
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeID == id);
        }
    }
}
