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
            var budgets = _context.Budgets.ToList();

            return Ok(budgets);
        }

        // GET A Budget by id
        // /Budgets/{Id}
        [HttpGet]
        public IHttpActionResult GetBudget(int id)
        {
            var budget = _context.Budgets.Single(b => b.Id == id);

            return Ok(budget);
        }

        // create a new Budget
        // POST /Budgets
        [HttpPost]
        public IHttpActionResult CreateBudget(Budget budget)
        {
            _context.Budgets.Add(budget);

            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + budget.Id), budget);
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
