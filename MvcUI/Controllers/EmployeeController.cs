using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MvcUI.Controllers;

public class EmployeeController : Controller
{
    // GET
    public async Task<IActionResult> Index()
    {
        var httpClient = new HttpClient();
        var responseMessage = await httpClient.GetAsync("https://localhost:7288/api/Default/getall");
        var jsonString = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<TempClass>>(jsonString);
        return View(values);
    }

    [HttpGet]
    public IActionResult AddEmployee()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddEmployee(TempClass employee)
    {
        var httpClient = new HttpClient();
        var jsonEmployee = JsonConvert.SerializeObject(employee);
        StringContent content = new StringContent(jsonEmployee,Encoding.UTF8,"application/json");
        var responseMessage = await httpClient.PostAsync("https://localhost:7288/api/Default/addemployee",content);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }

        return View(employee);
    }
}

public class TempClass
{
    public int Id { get; set; }
    public string Name { get; set; }
}