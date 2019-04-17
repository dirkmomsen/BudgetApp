using System;
using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Models
{
    public class Item
    {
        [Required]
        public byte Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public byte ItemTypeId { get; set; }
        public ItemType Type { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Value { get; set; }

    }
}