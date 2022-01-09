using AutoMapper;
using FreakyFashionServices.OrderProcessor.Models.DbModel;
using FreakyFashionServices.OrderProcessor.Models.Dtos;

namespace FreakyFashionServices.OrderService.Mapping
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>().ForMember(m => m.OrderCarts, 
                b => b.MapFrom(c => new OrderCart() 
                {   Identifier = c.Identifier, 
                    Lines = c.OrderLines
                }));
           
        }
    }
}
