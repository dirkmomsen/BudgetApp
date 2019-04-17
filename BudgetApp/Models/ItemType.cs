using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Models
{
    public class ItemType
    {
        public int TypeId { get; set; }

        [Required]
        [StringLength(3)]
        public string TypeCode { get; set; }

        [StringLength(255)]
        public string TypeName { get; set; }

        [StringLength(1)]
        public string Symbol { get; set; }
    }
}