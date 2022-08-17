using System;
using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class StoreUrlResolver : IValueResolver<Store, StoreToReturnDto, string>
    {
        private readonly IConfiguration _config;

        public StoreUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Store source, StoreToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ImageUrl))
            {
                return _config["ApiUrl"] + source.ImageUrl;
            }
            return null;
        }
    }
}
