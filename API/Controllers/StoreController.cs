using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class StoreController : BaseApiController
    {
        private readonly IGenericRepository<Store> _storeRepo;
        private readonly IMapper _mapper;

        public StoreController(IGenericRepository<Store> storeRepo,
            IMapper mapper)
        {
            _storeRepo = storeRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<StoreToReturnDto>>> GetStores()        
        {
            var spec = new StoreWithCountrySpecification();
            var data = await _storeRepo.ListAsync(spec);
            var dataMap = _mapper.Map<IReadOnlyList<Store>, IReadOnlyList<StoreToReturnDto>>(data);
            return Ok(dataMap);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StoreToReturnDto>> GetStore(int id)        
        {
            var spec = new StoreWithCountrySpecification(id);
            var data = await _storeRepo.GetEntityWithSpec(spec);
            return _mapper.Map<Store, StoreToReturnDto>(data);              
        }                
    }
}