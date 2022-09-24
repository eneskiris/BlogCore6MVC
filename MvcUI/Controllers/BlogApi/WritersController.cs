using System.Text;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MvcUI.Controllers;

public class WritersController : Controller
{
    // GET
    public async Task<IActionResult> Index()
    {
        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync("https://localhost:7288/api/Writers/getall");
        var json = await response.Content.ReadAsStringAsync();
        var writers = JsonConvert.DeserializeObject<List<Writer>>(json);
        return View(writers);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(Writer writer)
    {
        var httpClient = new HttpClient();
        var jsonWriter = JsonConvert.SerializeObject(writer);
        StringContent content = new StringContent(jsonWriter,Encoding.UTF8,"application/json");
        var responseMessage = await httpClient.PostAsync("https://localhost:7288/api/Writers/add",content);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }

        return View(writer);
    }
    
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var httpClient = new HttpClient();
        var responseMessage = await httpClient.GetAsync("https://localhost:7288/api/Default/update/" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonEmployee = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<Writer>(jsonEmployee);
            return View(value);
        }

        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Writer writer)
    {
        var httpClient = new HttpClient();
        var jsonEmployee = JsonConvert.SerializeObject(writer);
        var content = new StringContent(jsonEmployee,Encoding.UTF8,"application/json");
        var responseMessage = await httpClient.PutAsync("https://localhost:7288/api/Default/updateemployee?id=",content);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }

        return View(writer);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var httpClient = new HttpClient();
        var responseMessage = await httpClient.DeleteAsync("https://localhost:7288/api/Writers/delete?id=" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }

        return View();
    }

}