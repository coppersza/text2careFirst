using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypeStoreSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypeStoreSpecification()
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.Store);
        }

        public ProductsWithTypeStoreSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.Store);            
        }
    }
}
