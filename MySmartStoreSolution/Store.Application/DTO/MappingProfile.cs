using AutoMapper;
using Store.Application.DTO.Customer;
using Store.Application.DTO.Order;
using Store.Application.DTO.Product;
using Store.Application.DTO.User;

namespace Store.Application.DTO
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Domain.Entity.User, SignupRequestDTO>().ReverseMap();
            CreateMap<Domain.Entity.User, AuthenticateRequestDTO>().ReverseMap();
            CreateMap<Domain.Entity.User, AuthenticatedUserDTO>().ReverseMap();

            CreateMap<Domain.Entity.Customer, CustomerDto>().ReverseMap();
            CreateMap<Domain.Entity.Product, ProductDto>().ReverseMap();
            CreateMap<Domain.Entity.OrderItem, OrderItemDto>().ReverseMap();
        }
    }
}
