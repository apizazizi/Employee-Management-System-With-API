using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Controllers
{
    [Route("[controller]")]
    public class PayrollsController : Controller
    {
        private readonly EmployeeManagementContext _context;

        public PayrollsController(EmployeeManagementContext context)
        {
            _context = context;
        }

        // GET: Payrolls
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var payrolls = await _context.Payrolls.ToListAsync();
            return View(payrolls); // Returns the list view of payrolls
        }

        // GET: Payrolls/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var payroll = await _context.Payrolls.FindAsync(id);
            if (payroll == null)
            {
                return NotFound();
            }

            return View(payroll); // Returns the details view of a specific payroll
        }

        // GET: Payrolls/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View(); // Returns the view for creating a new payroll
        }

        // POST: Payrolls/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Payrolls payroll)
        {
            if (ModelState.IsValid)
            {
                _context.Add(payroll);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirects to the payroll list
            }
            return View(payroll);
        }

        // GET: Payrolls/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var payroll = await _context.Payrolls.FindAsync(id);
            if (payroll == null)
            {
                return NotFound();
            }
            return View(payroll); // Returns the edit view for a specific payroll
        }

        // POST: Payrolls/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Payrolls payroll)
        {
            if (id != payroll.PayrollID)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(payroll);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PayrollExists(id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index)); // Redirects to the payroll list
            }
            return View(payroll);
        }

        // GET: Payrolls/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var payroll = await _context.Payrolls.FindAsync(id);
            if (payroll == null)
            {
                return NotFound();
            }

            return View(payroll); // Returns the delete confirmation view
        }

        // POST: Payrolls/Delete/5
        [HttpPost("Delete/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var payroll = await _context.Payrolls.FindAsync(id);
            if (payroll != null)
            {
                _context.Payrolls.Remove(payroll);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index)); // Redirects to the payroll list
        }

        private bool PayrollExists(int id)
        {
            return _context.Payrolls.Any(e => e.PayrollID == id);
        }
    }
}
