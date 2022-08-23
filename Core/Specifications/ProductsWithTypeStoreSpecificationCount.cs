using Core.Entities;


namespace Core.Specifications
{
    public class ProductsWithTypeStoreSpecificationCount : BaseSpecification<Product>
    {
        public ProductsWithTypeStoreSpecificationCount(ProductSpecParams productSpecParams) : base(x =>
                (string.IsNullOrEmpty(productSpecParams.Search) || x.Name.ToLower().Contains(productSpecParams.Search)) &&
                (!productSpecParams.ProductTypeId.HasValue || x.ProductTypeId == productSpecParams.ProductTypeId) &&
                (!productSpecParams.StoreId.HasValue || x.StoreId == productSpecParams.StoreId)
            )
        {
        }
    }
}
