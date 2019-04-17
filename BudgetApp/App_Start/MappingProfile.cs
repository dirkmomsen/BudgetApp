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
            Mapper.CreateMap<ItemType, ItemTypeDto>();

            // Dto To Model
            Mapper.CreateMap<BudgetDto, Budget>()
                .ForMember(b => b.Id, opt => opt.Ignore());
            Mapper.CreateMap<ItemDto, Item>()
                .ForMember(i => i.Id, opt => opt.Ignore());
            Mapper.CreateMap<ItemTypeDto, ItemType>();
        }
    }
}