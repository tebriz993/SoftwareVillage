﻿using System.ComponentModel.DataAnnotations;

namespace SoftwareVillage.Models
{
    public class Layout
    {
        [Required]
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public Layout()
        {
            
        }
    }
}
