﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftwareVillage.Models
{
    public class Carousel_Design
    {
        [Required]
        public int Id { get; set; }
        public string? Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
    }
}
