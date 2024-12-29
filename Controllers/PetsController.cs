using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class PetsController : Controller
    {
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

        public IActionResult Index(string species = "", string ageRange = "")
        {
            var filteredPets = _pets.AsQueryable();

            // Tür filtreleme
            if (!string.IsNullOrEmpty(species))
            {
                filteredPets = filteredPets.Where(p => p.Species == species);
            }

            // Yaş filtreleme
            if (!string.IsNullOrEmpty(ageRange))
            {
                switch (ageRange)
                {
                    case "0-1":
                        filteredPets = filteredPets.Where(p => p.Age <= 1);
                        break;
                    case "1-3":
                        filteredPets = filteredPets.Where(p => p.Age > 1 && p.Age <= 3);
                        break;
                    case "3+":
                        filteredPets = filteredPets.Where(p => p.Age > 3);
                        break;
                }
            }

            // Mevcut filtreleri ViewBag'e ekle
            ViewBag.Species = species;
            ViewBag.AgeRange = ageRange;
            ViewBag.AvailableSpecies = _pets.Select(p => p.Species).Distinct().ToList();

            return View(filteredPets.ToList());
        }

        public IActionResult Details(int id)
        {
            var pet = _pets.FirstOrDefault(p => p.Id == id);
            if (pet == null)
            {
                return NotFound();
            }
            return View(pet);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Pet pet)
        {
            if (ModelState.IsValid)
            {
                pet.Id = _pets.Count > 0 ? _pets.Max(p => p.Id) + 1 : 1;
                pet.CreatedAt = DateTime.Now;
                _pets.Add(pet);
                return RedirectToAction(nameof(Index));
            }
            return View(pet);
        }
    }
} 