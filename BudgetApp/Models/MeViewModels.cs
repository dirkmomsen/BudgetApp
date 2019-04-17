using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Models
{
    // Models returned by MeController actions.
    public class GetViewModel
    {
        public IEnumerable<Budget> Budgets { get; set; }
    }
}