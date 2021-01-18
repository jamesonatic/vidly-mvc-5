﻿using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>().ForMember(c => c.Id,opt =>opt.Ignore());
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c=>c.Id,opt=>opt.Ignore());
        }
    }
}