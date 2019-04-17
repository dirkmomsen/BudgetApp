using System;
using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Models
{
    public class Item
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        public int ItemTypeId { get; set; }
        public ItemType ItemType { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Value { get; set; }

        public int BudgetId { get; set; }
    }
}