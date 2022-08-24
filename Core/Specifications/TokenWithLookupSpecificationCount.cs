using System;
using Core.Entities;

namespace Core.Specifications
{
    public class TokenWithLookupSpecificationCount : BaseSpecification<Token>
    {
        public TokenWithLookupSpecificationCount(string email, TokenSpecParams specParams) : base(x => 
                (x.BuyerEmail == email) &&
                (string.IsNullOrEmpty(specParams.Search) || x.TokenName.ToLower().Contains(specParams.Search)) &&
                (!specParams.ProductTypeId.HasValue || x.Product.ProductTypeId == specParams.ProductTypeId) && 
                (!specParams.StoreId.HasValue || x.Store.Id == specParams.StoreId) && 
                (!specParams.RecipientId.HasValue || x.RecipientId == specParams.RecipientId) && 
                (!specParams.DonatorId.HasValue || x.DonatorId == specParams.DonatorId) )
        {
        }              
        public TokenWithLookupSpecificationCount(TokenSpecParams specParams) : base(x => 
                (string.IsNullOrEmpty(specParams.Search) || x.TokenName.ToLower().Contains(specParams.Search)) &&
                (!specParams.ProductTypeId.HasValue || x.Product.ProductTypeId == specParams.ProductTypeId) && 
                (!specParams.StoreId.HasValue || x.Store.Id == specParams.StoreId) && 
                (!specParams.RecipientId.HasValue || x.RecipientId == specParams.RecipientId) && 
                (!specParams.DonatorId.HasValue || x.DonatorId == specParams.DonatorId) )
        {
        }        
 
    }
}
