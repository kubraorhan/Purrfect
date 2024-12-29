using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private static List<Pet> _pets = new List<Pet>
    {
        new Pet
        {
            Id = 1,
            Name = "Luna",
            Species = "Kedi",
            Breed = "British Shorthair",
            Age = 2,
            Gender = "Dişi",
            Description = "Sevimli ve oyuncu bir kedi. Diğer kedilerle iyi anlaşıyor.",
            ImageUrl = "https://placekitten.com/400/300",
            HealthStatus = "Aşıları tam"
        },
        new Pet
        {
            Id = 2,
            Name = "Max",
            Species = "Köpek",
            Breed = "Golden Retriever",
            Age = 1,
            Gender = "Erkek",
            Description = "Enerjik ve arkadaş canlısı. Çocuklarla çok iyi anlaşıyor.",
            ImageUrl = "https://images.dog.ceo/breeds/retriever-golden/n02099601_1024.jpg",
            HealthStatus = "Aşıları tam"
        },
        new Pet
        {
            Id = 3,
            Name = "Pamuk",
            Species = "Tavşan",
            Breed = "Holland Lop",
            Age = 1,
            Gender = "Erkek",
            Description = "Sevimli ve sakin bir tavşan. Ev ortamına alışkın.",
            ImageUrl = "https://images.unsplash.com/photo-1585110396000-c9ffd4e4b308",
            HealthStatus = "Sağlıklı"
        }
    };

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.Title = "Ana Sayfa";
        return View(_pets);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
