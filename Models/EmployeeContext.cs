using Microsoft.EntityFrameworkCore; 

namespace SecondTestAPI.Models  
{
    public class EmployeeContext : DbContext  
    {  
        public EmployeeContext(DbContextOptions options) : base(options) 
        {
            
        }  
        public DbSet<Employee> Employees {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employee");
            
        }
    }
} 