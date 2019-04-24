using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using BudgetApp.Dtos;
using BudgetApp.Models;

namespace BudgetApp.Controllers.Api
{
    [RoutePrefix("api/budgets/{budgetId:int}/items/")]
    public class ItemsController : ApiController
    {
        private ApplicationDbContext _context;

        public ItemsController()
        {
            _context = new ApplicationDbContext();
        }

        // Get all Items for budget
        // GET /Budgets/{budgetId}/Items
        public IHttpActionResult GetItems(int budgetId)
        {
            var budget = _context.Budgets.SingleOrDefault(b => b.Id == budgetId);

            if (budget == null)
                return NotFound();

            var itemDtos = budget.Items.Select(Mapper.Map<Item, ItemDto>);

            return Ok(itemDtos);
        }

        // Get specific Item for specific budget
        public IHttpActionResult GetItem(int budgetId, int id)
        {
            var budget = _context.Budgets.
        }
    }
}
