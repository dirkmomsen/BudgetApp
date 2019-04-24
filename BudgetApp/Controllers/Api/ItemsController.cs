﻿using System;
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
    [RoutePrefix("api/budgets/{budgetId:int}/items")]
    public class ItemsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public ItemsController()
        {
            _context = new ApplicationDbContext();
        }

        // Get all Items for budget
        // GET /Budgets/{budgetId}/Items
        [Route("")]
        public IHttpActionResult GetItems(int budgetId)
        {
            var budget = _context.Budgets
                .Include(b => b.Items)
                .Include(b => b.Items.Select(i => i.ItemType))
                .SingleOrDefault(b => b.Id == budgetId);

            if (budget == null)
                return NotFound();

            var itemDtos = budget.Items.Select(Mapper.Map<Item, ItemDto>);

            return Ok(itemDtos);
        }

        // Get specific Item for specific budget
        // GET /Budgets/{budgetId}/Items/{id}
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetItem(int budgetId, int id)
        {
            var item = _context.Items
                .Include(i => i.ItemType)
                .SingleOrDefault(i => i.Id == id && i.BudgetId == budgetId);

            if (item == null)
                return NotFound();

            return Ok(Mapper.Map<Item, ItemDto>(item));
        }

        // Create a new Item
        // POST /Budgets/{budgetId}/Items
        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateItem(int budgetId, ItemDto itemDto)
        {
            //Check if itemDto is valid.
            if (!ModelState.IsValid)
                return BadRequest();

            // Check if budget exist. Handle null.
            var budget = _context.Budgets.SingleOrDefault(b => b.Id == budgetId);

            if (budget == null)
                return NotFound();

            // Create new Item
            var item = Mapper.Map<ItemDto, Item>(itemDto);

            // Add item to context and save.
            _context.Items.Add(item);
            _context.SaveChanges();

            // Return Created with url.
            itemDto.Id = item.Id;
            return Created(new Uri(Request.RequestUri + "/" + itemDto.Id), itemDto);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}
