using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging; 
using SecondTestAPI.Models;  

namespace SecondTestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeContext _context; 
        public EmployeeController(EmployeeContext context)
        {
            _context = context;  
        }
       
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetEmployee()
        {
           return _context.Employees;
        }
    }
}
