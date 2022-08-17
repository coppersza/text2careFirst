using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class EmployeeController : BaseApiController
    {
        private readonly IGenericRepository<Employee> _employeeRepo;
        private readonly IMapper _mapper;

        public EmployeeController(IGenericRepository<Employee> employeeRepo,
            IMapper mapper)
        {
            _employeeRepo = employeeRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<EmployeeToReturnDto>>> GetEmployees()
        {
            var spec = new EmployeeWithCountrySpecification();
            var data = await _employeeRepo.ListAsync(spec);
            var mapData = _mapper.Map<IReadOnlyList<Employee>, IReadOnlyList<EmployeeToReturnDto>>(data);
            return Ok(mapData);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeToReturnDto>> GetEmployee(int id)        
        {
            var spec = new EmployeeWithCountrySpecification(id);
            var data = await _employeeRepo.GetEntityWithSpec(spec);
            return _mapper.Map<Employee, EmployeeToReturnDto>(data);              
        }                
    }     
}
