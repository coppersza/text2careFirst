using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class StoreWithCountrySpecification : BaseSpecification<Store>
    {
        public StoreWithCountrySpecification()
        {
            AddInclude(x => x.Country);
        }

        public StoreWithCountrySpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Country);
        }
    }
}
