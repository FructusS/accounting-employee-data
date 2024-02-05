using AccountingEmployeeData.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using AccountingEmployeeData.Data.Entities;

namespace AccountingEmployeeData.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<EmployeeEntity> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeEntityConfiguration());
        }
        
    }
}
