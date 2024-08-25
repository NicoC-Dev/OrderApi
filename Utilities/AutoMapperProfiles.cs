using AutoMapper;
using OrderApi.DTOs;
using OrdersApi.DTOs;
using OrdersApi.Models;

namespace MaestroApi.Utilities;

public class AutoMapperProfiles : Profile
{

    public AutoMapperProfiles()
    {
        CreateMap<ProductDTO, Product>();

        CreateMap<OrderDetailDTO, OrderDetail>()
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId));
        
        CreateMap<CreateOrderDTO, Order>()
            .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails));
            

        



        

    }
}