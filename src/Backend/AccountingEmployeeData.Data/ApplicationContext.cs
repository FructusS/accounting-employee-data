using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingEmployeeData.Data.Entities;

namespace AccountingEmployeeData.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }
        
        
        public DbSet<EmployeeEntity> Employees { get; set; }
        
        
        
    }
}
