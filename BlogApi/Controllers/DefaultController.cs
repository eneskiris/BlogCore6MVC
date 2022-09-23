using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApi.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet("getall")]
        public IActionResult EmployeeList()
        {
            using (var context = new BlogApiDemoContext())
            {
                var values = context.Employees.ToList();
                return Ok(values);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            using (var context = new BlogApiDemoContext())
            {
                var employee = context.Employees.Find(id);
                if (employee==null)
                {
                    return NotFound();
                }
                return Ok(employee);
            }
        }
        
        [HttpPost("addemployee")]
        public IActionResult AddEmployee(Employee employee)
        {
            using ( var context = new BlogApiDemoContext())
            {
                context.Add(employee);
                context.SaveChanges();
                return Ok();
            }
        }
    }
}
