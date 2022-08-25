using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class DonatorController : BaseApiController
    {
        private readonly IGenericRepository<Donator> _donatorRepo;
        private readonly IMapper _mapper;

        public DonatorController(IGenericRepository<Donator> donatorRepo,
            IMapper mapper)
        {
            _donatorRepo = donatorRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<DonatorToReturnDto>>> GetDonators()
        {
            var spec = new DonatorWithCountrySpecification();
            var data = await _donatorRepo.ListAsync(spec);
            var mapData = _mapper.Map<IReadOnlyList<Donator>, IReadOnlyList<DonatorToReturnDto>>(data);
            return Ok(mapData);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DonatorToReturnDto>> GetDonator(int id)        
        {
            var spec = new DonatorWithCountrySpecification(id);
            var data = await _donatorRepo.GetEntityWithSpec(spec);
            return _mapper.Map<Donator, DonatorToReturnDto>(data);              
        }                
    }    
    
}
