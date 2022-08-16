using System;
using API.Dtos;
using AutoMapper;
using Core.Entities;

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
        }
    }
}
