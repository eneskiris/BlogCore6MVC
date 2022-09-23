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

        [HttpGet("getbyid")]
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

        [HttpDelete("delete")]
        public IActionResult DeleteEmployee(int id)
        {
            using ( var context = new BlogApiDemoContext())
            {
                var employee = context.Employees.Find(id);
                if (employee == null)
                {
                    return NotFound();
                }

                context.Remove(employee);
                context.SaveChanges();
                return Ok();
            }
        }

        [HttpPut("updateemployee")]
        public IActionResult UpdateEmployee(Employee employee)
        {
            using ( var context = new BlogApiDemoContext())
            {
                var updateEmployee = context.Employees.Find(employee.Id);
                if (updateEmployee == null)
                {
                    return NotFound();
                }

                updateEmployee.Name = employee.Name;
                context.Update(updateEmployee);
                context.SaveChanges();
                return Ok();
            }
        }
    }
}
