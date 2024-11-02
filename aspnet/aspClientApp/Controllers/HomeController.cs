using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using aspClientApp.Models;
using System.Text.Json;

namespace aspClientApp.Controllers;

public class HomeController : Controller
{
    public async Task<IActionResult> Index()
    {
        var products = new List<ProductDTO>();
        
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync("http://localhost:5280/api/products/"))
            {
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    try
                    {
                        products = JsonSerializer.Deserialize<List<ProductDTO>>(apiResponse);
                    }
                    catch (JsonException ex)
                    {
                        Debug.WriteLine($"JSON Hatası: {ex.Message}");
                        // Hata durumu için uygun bir işlem yapabilirsiniz
                    }
                }
                else
                {
                    Debug.WriteLine($"API Hatası: {response.StatusCode}");
                    // API çağrısı başarısızsa uygun bir işlem yapın
                }
            }
        }

        return View(products);
    }

    
    public async Task<IActionResult> Login(int id)
    {
        ProductDTO product = null;

        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync($"http://localhost:5280/api/products/{id}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    try
                    {
                        product = JsonSerializer.Deserialize<ProductDTO>(apiResponse);
                    }
                    catch (JsonException ex)
                    {
                        Debug.WriteLine($"JSON Hatası: {ex.Message}");
                        // Hata durumu için uygun bir işlem yapabilirsiniz
                    }
                }
                else
                {
                    Debug.WriteLine($"API Hatası: {response.StatusCode}");
                    // API çağrısı başarısızsa uygun bir işlem yapın
                }
            }
        }

        if (product == null)
        {
            return NotFound();
        }

        return Json(product);
    }
}
