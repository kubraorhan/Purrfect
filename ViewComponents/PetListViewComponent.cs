using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.ViewComponents
{
    public class PetListViewComponent : ViewComponent
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

        public IViewComponentResult Invoke(int count = 3)
        {
            return View(_pets.Take(count).ToList());
        }
    }
} 