using System.Text.Json;
using aspClientApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace aspClientApp.Controllers
{
    public class IdController: Controller
    {
         public async Task<IActionResult> Index()
    {
        var products = new List<ProductDTO>();
        
        using(var httpClient = new HttpClient())
        {
            using(var response = await httpClient.GetAsync("http://localhost:5280/api/products/{id}"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                products = JsonSerializer.Deserialize<List<ProductDTO>>(apiResponse);
            }
        }

        return View(products);

    }
    }
}