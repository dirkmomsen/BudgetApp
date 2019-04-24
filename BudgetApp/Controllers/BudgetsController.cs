using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BudgetApp.Controllers
{
    public class BudgetsController : Controller
    {
        // GET: Budgets
        public ActionResult Index()
        {
            return View();
        }
    }
}