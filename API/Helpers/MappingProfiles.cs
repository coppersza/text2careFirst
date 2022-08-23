using System;
using API.Dtos;
using API.Dtos.Orders;
using API.Dtos.Users;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;
using Core.Entities.OrderAggregate;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.Store, o => o.MapFrom(s => s.Store.StoreName))
                .ForMember(d => d.ImageUrl, o => o.MapFrom<ProductUrlResolver>());
            CreateMap<Store, StoreToReturnDto>()
                .ForMember(d => d.Country, o => o.MapFrom(s => s.Country.Name))
                .ForMember(d => d.ImageUrl, o => o.MapFrom<StoreUrlResolver>());
                
            CreateMap<Recipient, RecipientToReturnDto>()
                .ForMember(d => d.Country, o => o.MapFrom(s => s.Country.Name));      
            CreateMap<Employee, EmployeeToReturnDto>()
                .ForMember(d => d.Country, o => o.MapFrom(s => s.Country.Name));    
            CreateMap<Donator, DonatorToReturnDto>()
                .ForMember(d => d.Country, o => o.MapFrom(s => s.Country.Name));          

            CreateMap<Token, TokenToReturnDto>()
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.Store, o => o.MapFrom(s => s.Store.StoreName))
                .ForMember(d => d.Product, o => o.MapFrom(s => s.Product.Name))
                .ForMember(d => d.Recipient, o => o.MapFrom(s => s.Recipient.FullName))
                .ForMember(d => d.Donator, o => o.MapFrom(s => s.Donator.FullName));

            // CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<Core.Entities.Identity.Address, AddressDto>().ReverseMap();

            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemDto, BasketItem>();      
            CreateMap<AddressDto, Core.Entities.OrderAggregate.Address>();  
                
            CreateMap<Order, OrderToReturnDto>()
                .ForMember(d => d.DeliveryMethod, o => o.MapFrom(s => s.DeliveryMethod.ShortName))
                .ForMember(d => d.ShippingPrice, o => o.MapFrom(s => s.DeliveryMethod.Price));

            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ItemOrdered.ProductItemId))
                .ForMember(d => d.ProductName, o => o.MapFrom(s => s.ItemOrdered.ProductName))
                .ForMember(d => d.ImageUrl, o => o.MapFrom(s => s.ItemOrdered.ImageUrl))
                .ForMember(d => d.ImageUrl, o=> o.MapFrom<OrderItemUrlResolver>());            
                 
        }
    }
}
