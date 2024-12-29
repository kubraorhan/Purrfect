using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Pet
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Species { get; set; } // Kedi, Köpek, vb.

        public string Breed { get; set; } // Irk

        public int Age { get; set; }

        public string Gender { get; set; }

        [Required]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public bool IsAvailable { get; set; } = true;

        public string HealthStatus { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
} 