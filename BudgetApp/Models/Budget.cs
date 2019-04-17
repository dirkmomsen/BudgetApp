using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BudgetApp.Models
{
    public class Budget
    {
        public byte Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public IEnumerable<Item> Items { get; set; }

        [StringLength(3)]
        public string Currency { get; set; }
    }
}