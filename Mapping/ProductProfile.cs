using AutoMapper;
using product_service_api.DTO;
using product_service_api.Model;

namespace product_service_api.Mapping;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProduct, Product>();

        CreateMap<Product, ProductDTO>();
    }
}