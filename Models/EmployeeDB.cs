using Microsoft.AspNetCore.Builder;  
using Microsoft.EntityFrameworkCore;  
using Microsoft.Extensions.DependencyInjection;
using System.Linq;  

namespace SecondTestAPI.Models  
{
    public class EmployeeDB  
    {
        public static void PrePopulation(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())  
            {
                SeedData(scope.ServiceProvider.GetService<EmployeeContext>()); 
            }
        }
        public static void SeedData(EmployeeContext context)
        {
            context.Database.EnsureCreated();

            if(!context.Employees.Any())
            {
                context.Employees.AddRange(
                    new Employee() { EmployeeName="Emp1"},
                    new Employee() {  EmployeeName="Emp2"},
                    new Employee() {  EmployeeName="Emp3"},
                    new Employee() {  EmployeeName="Emp4"},
                    new Employee() {  EmployeeName="Emp5"},
                    new Employee() {  EmployeeName="Emp6"}, 
                    new Employee() {  EmployeeName="Emp7"}, 
                    new Employee() {  EmployeeName="Emp8"}
                );  
                context.SaveChanges();  
            }
            else  
            {
                System.Console.WriteLine("Data not seeding");  
            }
        }
    }
}