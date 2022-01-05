﻿using AutoMapper;
using FreakyFashionServices.OrderService.Models.DbModel;
using FreakyFashionServices.OrderService.Models.Dtos;

namespace FreakyFashionServices.OrderService.Mapping
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, ReadOrderDto>();
            CreateMap<CreateOrderDto, Order>().ForMember(m => m.OrderId, d => d.MapFrom(r => Guid.NewGuid()));
        }
    }
}
