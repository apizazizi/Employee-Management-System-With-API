using Microsoft.EntityFrameworkCore;
using EmployeeManagementAPI.Models;

namespace EmployeeManagementAPI.Data
{
    public class EmployeeManagementContext : DbContext
    {
        public EmployeeManagementContext(DbContextOptions<EmployeeManagementContext> options) : base(options) { }

        public DbSet<Employees> Employees { get; set; }
        public DbSet<Payrolls> Payrolls { get; set; }
    }
}

