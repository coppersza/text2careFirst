using System;
using API.Dtos;
using API.Errors;
using API.Extensions;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class TokenControllerUser : BaseApiController
    {
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public TokenControllerUser(ITokenService tokenService, IMapper mapper)
        {
            _tokenService = tokenService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult<Token>> CreateToken(TokenDto tokenDto){
            var email = HttpContext.User.RetrieveEmailFromPrincipal();
            var product = _mapper.Map<ProductDto, Product>(tokenDto.Product);
            var token = await _tokenService.CreateTokenAsync(email, tokenDto.TokenName, tokenDto.ProductId);

            if (token == null) return BadRequest(new ApiResponse(400, "Problem creating order"));
            return Ok(token);
        }
    }
}
