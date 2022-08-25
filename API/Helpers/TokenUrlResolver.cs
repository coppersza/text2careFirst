using System;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class TokenUrlResolver : IValueResolver<Token, TokenToReturnDto, string>
    {
        private readonly IConfiguration _config;

        public TokenUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Token source, TokenToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ImageUrl) && source.ImageUrl.StartsWith("images") )
            {
                return _config["ApiUrl"] + source.ImageUrl;
            }
            return source.ImageUrl;
        }
    }
}
