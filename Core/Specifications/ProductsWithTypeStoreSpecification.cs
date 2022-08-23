using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypeStoreSpecification : BaseSpecification<Product>
    {

        public ProductsWithTypeStoreSpecification(ProductSpecParams productSpecParams) 
            : base(x => 
                (string.IsNullOrEmpty(productSpecParams.Search) || x.Name.ToLower().Contains(productSpecParams.Search)) &&
                (!productSpecParams.ProductTypeId.HasValue || x.ProductTypeId == productSpecParams.ProductTypeId) && 
                (!productSpecParams.StoreId.HasValue || x.StoreId == productSpecParams.StoreId)
            )
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.Store);
            AddOrderBy(x => x.Name);
            ApplyPaging(productSpecParams.PageSize * (productSpecParams.PageIndex - 1), productSpecParams.PageSize);
            if (!string.IsNullOrEmpty(productSpecParams.Sort)){
                switch (productSpecParams.Sort){
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;                      
                }
            }
        }

        public ProductsWithTypeStoreSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.Store);            
        }
    }
}
