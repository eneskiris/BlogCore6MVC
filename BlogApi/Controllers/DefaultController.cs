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
