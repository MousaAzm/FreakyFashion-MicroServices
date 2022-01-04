using AutoMapper;
using FreakyFashionServices.OrderService.Models.DbModel;
using FreakyFashionServices.OrderService.Models.Dtos;

namespace FreakyFashionServices.OrderService.Mapping
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, ReadOrderDto>();
            CreateMap<CreateOrderDto, Order>();
            CreateMap<UpdateOrderDto, Order>();
        }
    }
}
