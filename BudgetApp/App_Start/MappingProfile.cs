using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BudgetApp.Dtos;
using BudgetApp.Models;

namespace BudgetApp.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Model To Dto
            Mapper.CreateMap<Budget, BudgetDto>();
            Mapper.CreateMap<Item, ItemDto>();

            // Dto To Model
            Mapper.CreateMap<BudgetDto, Budget>();
            Mapper.CreateMap<ItemDto, Item>();
        }
    }
}