using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    public class TokenController : BaseApiController
    {
        private readonly IGenericRepository<Token> _tokenRepo;
        private readonly IMapper _mapper;

        public TokenController(IGenericRepository<Token> tokenRepo,
            IMapper mapper)
        {
            _tokenRepo = tokenRepo;
            _mapper = mapper;
        }
        // [Cached(600)]
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<TokenToReturnDto>>> GetTokens([FromQuery]TokenSpecParams specParams)        
        {
            var spec = new TokenWithLookupSpecification(specParams);
            var countSpec = new TokenWithLookupSpecificationCount(specParams);
            var totalItems = await _tokenRepo.CountAsync(countSpec);

            var data = await _tokenRepo.ListAsync(spec);
            var dataMap = _mapper.Map<IReadOnlyList<Token>, IReadOnlyList<TokenToReturnDto>>(data);
            return Ok(new Pagination<TokenToReturnDto>(specParams.PageIndex, specParams.PageSize, totalItems, dataMap));
            // return Ok(dataMap);
        }
        // [Cached(600)]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TokenToReturnDto>> GetToken(int id)        
        {
            var spec = new TokenWithLookupSpecification(id);
            var data = await _tokenRepo.GetEntityWithSpec(spec);
            if (data == null) return NotFound(new ApiResponse(404));
            return _mapper.Map<Token, TokenToReturnDto>(data);              
        }                
    }    
}
