﻿using System.ComponentModel.DataAnnotations;

namespace ExpensesTracker.Models
{
    public class UpdateExpensesDto
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal ? Price { get; set; }
    }
}
