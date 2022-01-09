using AutoMapper;
using FreakyFashionServices.StockService.Models.DbModel;
using FreakyFashionServices.StockService.Models.Dtos;

namespace FreakyFashionServices.StockService.Mapping
{
    public class StockProfile : Profile
    {
        public StockProfile()
        {
            CreateMap<Stock, StockDto>();
            CreateMap<StockDto, Stock>();
        }
    }
}
