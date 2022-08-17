using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class RecipientController : BaseApiController
    {
        private readonly IGenericRepository<Recipient> _recipientRepo;
        private readonly IMapper _mapper;

        public RecipientController(IGenericRepository<Recipient> recipientRepo,
            IMapper mapper)
        {
            _recipientRepo = recipientRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<RecipientToReturnDto>>> GetRecipients()
        {
            var spec = new RecipientWithCountrySpecification();
            var data = await _recipientRepo.ListAsync(spec);
            var dataMap = _mapper.Map<IReadOnlyList<Recipient>, IReadOnlyList<RecipientToReturnDto>>(data);
            return Ok(dataMap);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RecipientToReturnDto>> GetRecipient(int id)        
        {
            var spec = new RecipientWithCountrySpecification(id);
            var data = await _recipientRepo.GetEntityWithSpec(spec);
            return _mapper.Map<Recipient, RecipientToReturnDto>(data);              
        }                
    }
}
