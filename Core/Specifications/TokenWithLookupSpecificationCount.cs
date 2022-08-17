using System;
using Core.Entities;

namespace Core.Specifications
{
    public class TokenWithLookupSpecificationCount : BaseSpecification<Token>
    {
        public TokenWithLookupSpecificationCount(TokenSpecParams specParams) : base(x => 
                (string.IsNullOrEmpty(specParams.Search) || x.TokenName.ToLower().Contains(specParams.Search)) &&
                (!specParams.TypeId.HasValue || x.ProductTypeId == specParams.TypeId) && 
                (!specParams.StoreId.HasValue || x.StoreId == specParams.StoreId) && 
                (!specParams.RecipientId.HasValue || x.RecipientId == specParams.RecipientId) && 
                (!specParams.DonatorId.HasValue || x.DonatorId == specParams.DonatorId) )
        {
        }        
 
    }
}
