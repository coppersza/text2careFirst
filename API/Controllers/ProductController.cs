using API.Dtos;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IGenericRepository<Store> _storeRepo;
        private readonly IMapper _mapper;

        public ProductController(IGenericRepository<Product> productRepo, 
            IGenericRepository<ProductType> productTypeRepo,
            IGenericRepository<Store> storeRepo,
            IMapper mapper)
        {
            _productRepo = productRepo;
            _productTypeRepo = productTypeRepo;
            _storeRepo = storeRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts([FromQuery]ProductSpecParams productSpecParams)
        {
            var spec = new ProductsWithTypeStoreSpecification(productSpecParams);
            var countSpec = new ProductsWithTypeStoreSpecificationCount(productSpecParams);
            var totalItems = await _productRepo.CountAsync(countSpec);

            var products = await _productRepo.ListAsync(spec);
            var dataMap = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);

            return Ok(new Pagination<ProductToReturnDto>(productSpecParams.PageIndex, productSpecParams.PageSize, totalItems, dataMap));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithTypeStoreSpecification(id);
            var product = await _productRepo.GetEntityWithSpec(spec);
            if (product == null) return NotFound(new ApiResponse(404));
            return _mapper.Map<Product, ProductToReturnDto>(product);

            // var product = await _productRepo.GetByIdAsync(id);
            // return new ProductToReturnDto{
            //     Id = product.Id,
            //     Name = product.Name,
            //     Description = product.Description,
            //     Price = product.Price,
            //     PictureUrl = product.PictureUrl,
            //     ProductType = product.ProductType.Name,
            //     Store = product.Store.Name
            // };

        }

        [HttpGet("store")]
        public async Task<ActionResult<IReadOnlyList<StoreToReturnDto>>> GetStores()        
        {
            var spec = new StoreWithCountrySpecification();
            var stores = await _storeRepo.ListAsync(spec);
            var data = _mapper.Map<IReadOnlyList<Store>, IReadOnlyList<StoreToReturnDto>>(stores);
            // var stores = await _storeRepo.ListAllAsync();
            return Ok(data);
        }
        [HttpGet("store/{id}")]
        public async Task<ActionResult<StoreToReturnDto>> GetStore(int id)        
        {
            var spec = new StoreWithCountrySpecification(id);
            // return await _storeRepo.GetEntityWithSpec(spec);
            var store = await _storeRepo.GetEntityWithSpec(spec);
            return _mapper.Map<Store, StoreToReturnDto>(store);    
            // var spec = new StoreWithCountrySpecification(id);
            // var store = await _storeRepo.GetEntityWithSpec(spec);
            // if (store == null) return NotFound(new ApiResponse(404));
            // return _mapper.Map<Store, StoreToReturnDto>(store);                   
        }        

        [HttpGet("type")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            var productTypes = await _productTypeRepo.ListAllAsync();
            return Ok(productTypes);
        }                
    }
}
