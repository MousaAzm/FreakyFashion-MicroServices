using AutoMapper;
using FreakyFashionServices.CatalogService.Helper;
using FreakyFashionServices.CatalogService.Models.DbModel;
using FreakyFashionServices.CatalogService.Models.Dtos;

namespace FreakyFashionServices.CatalogService.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ReadProductDto>();
            CreateMap<CreateProductDto, Product>()
                .ForMember(m => m.UrlSlug, d => d.MapFrom(r => GetUrlSlug.ToUrlSlug(r.Name)));
            CreateMap<UpdateProductDto, Product>()
                .ForMember(m => m.UrlSlug, d => d.MapFrom(r => GetUrlSlug.ToUrlSlug(r.Name))); ;
        }

    }
}
