using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BudgetApp.Models;

namespace BudgetApp.Dtos
{
    public class ItemDto
    {
        [Required]
        public byte Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        public byte ItemTypeId { get; set; }
        public ItemType ItemType { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Value { get; set; }

        public int BudgetId { get; set; }
    }
}