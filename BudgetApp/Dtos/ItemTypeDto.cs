using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BudgetApp.Dtos
{
    public class ItemTypeDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(3)]
        public string TypeCode { get; set; }

        [StringLength(255)]
        public string TypeName { get; set; }

        [StringLength(1)]
        public string Symbol { get; set; }
    }
}