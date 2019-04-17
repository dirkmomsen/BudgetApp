using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using BudgetApp.Dtos;
using BudgetApp.Models;

namespace BudgetApp.Controllers.Api
{
    public class BudgetsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public BudgetsController()
        {
            _context = new ApplicationDbContext();
        }

        // Get All Budgets for User
        // GET /Budgets
        [HttpGet]
        public IHttpActionResult GetBudgets()
        {
            var budgetDtos = _context.Budgets
                .ToList()
                .Select(Mapper.Map<Budget, BudgetDto>);

            return Ok(budgetDtos);
        }

        // GET A Budget by id
        // /Budgets/{Id}
        [HttpGet]
        public IHttpActionResult GetBudget(int id)
        {
            var budget = _context.Budgets
                .Include(b => b.Items)
                .Include(b => b.Items.Select(i => i.ItemType))
                .Single(b => b.Id == id);

            if (budget == null)
                return NotFound();

            return Ok(Mapper.Map<Budget, BudgetDto>(budget));
        }

        // create a new Budget
        // POST /Budgets
        [HttpPost]
        public IHttpActionResult CreateBudget(BudgetDto budgetDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var budget = Mapper.Map<BudgetDto, Budget>(budgetDto);

            _context.Budgets.Add(budget);
            _context.SaveChanges();

            budgetDto.Id = budget.Id;

            return Created(new Uri(Request.RequestUri + "/" + budgetDto.Id), budgetDto);
        }

        // Edit an existing budget
        // PUT /Budgets/{id}
        [HttpPut]
        public IHttpActionResult EditBudget(int id, BudgetDto budgetDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var budgetInDb = _context.Budgets.Single(b => b.Id == id);

            if (budgetInDb == null)
                return NotFound();

            Mapper.Map(budgetDto, budgetInDb);

            _context.SaveChanges();

            return Ok();
        }

        // Delete a Budget
        // DELETE /Budgets/{id}
        [HttpDelete]
        public IHttpActionResult DeleteBudget(int id)
        {
            var budgetInDb = _context.Budgets.Single(b => b.Id == id);

            if (budgetInDb == null)
                return NotFound();

            _context.Budgets.Remove(budgetInDb);
            _context.SaveChanges();

            return Ok();

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}
