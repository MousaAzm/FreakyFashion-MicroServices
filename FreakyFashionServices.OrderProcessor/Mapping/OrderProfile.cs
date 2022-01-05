using AutoMapper;
using FreakyFashionServices.OrderProcessor.Models.DbModel;
using FreakyFashionServices.OrderProcessor.Models.Dtos;

namespace FreakyFashionServices.OrderService.Mapping
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, ReadOrderDto>();
            CreateMap<CreateOrderDto, Order>();
        }
    }
}
