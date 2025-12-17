using AutoMapper;
using MiniShopMVC.Models;
using MiniShopMVC.Models.Entities;

namespace MiniShopMVC.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ProductAddViewModel, Product>();
            CreateMap<CategoryAddViewModel, Category>();

            CreateMap<CategoryUpdateViewModel, Category>();
            CreateMap<ProductUpdateViewModel, Product>();
            
            CreateMap<OrderAddViewModel, Order>();
            CreateMap<OrderUpdateViewModel, Order>();
            

        }
    }
}
    
