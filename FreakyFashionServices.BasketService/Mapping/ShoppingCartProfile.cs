using AutoMapper;
using FreakyFashionServices.BasketService.Models.DbModel;
using FreakyFashionServices.BasketService.Models.Dtos;

namespace FreakyFashionServices.BasketService.Mapping
{
    public class ShoppingCartProfile : Profile
    {
        public ShoppingCartProfile()
        {
            CreateMap<ShoppingCart, ReadShoppingCartDto>();
            CreateMap<CreateShoppingCartDto, ShoppingCart>();
        }
    }
}
