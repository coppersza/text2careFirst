using System;
using API.Dtos;
using API.Dtos.Users;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;

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
                .ForMember(d => d.Recipient, o => o.MapFrom(s => s.Recipient.FullName))
                .ForMember(d => d.Donator, o => o.MapFrom(s => s.Donator.FullName));

            CreateMap<CustomerBasket, CustomerBasketDto>();
            CreateMap<BasketItem, BasketItemDto>();                
            CreateMap<Address, AddressDto>().ReverseMap();                
        }
    }
}
