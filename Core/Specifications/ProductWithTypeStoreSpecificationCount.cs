using Core.Entities;


namespace Core.Specifications
{
    public class ProductWithTypeStoreSpecificationCount : BaseSpecification<Product>
    {
        public ProductWithTypeStoreSpecificationCount(ProductSpecParams productSpecParams) : base(x =>
                (string.IsNullOrEmpty(productSpecParams.Search) || x.Name.ToLower().Contains(productSpecParams.Search)) &&
                (!productSpecParams.ProductTypeId.HasValue || x.ProductTypeId == productSpecParams.ProductTypeId) &&
                (!productSpecParams.StoreId.HasValue || x.StoreId == productSpecParams.StoreId)
            )
        {
        }
    }
}
