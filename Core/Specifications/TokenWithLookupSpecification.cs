using System;
using Core.Entities;
namespace Core.Specifications
{
    public class TokenWithLookupSpecification: BaseSpecification<Token>
    {
        public TokenWithLookupSpecification(TokenSpecParams specParams) : base(x => 
                (string.IsNullOrEmpty(specParams.Search) || x.TokenName.ToLower().Contains(specParams.Search)) &&
                (!specParams.ProductTypeId.HasValue || x.ProductType.Id == specParams.ProductTypeId) && 
                (!specParams.StoreId.HasValue || x.Store.Id == specParams.StoreId) && 
                (!specParams.RecipientId.HasValue || x.RecipientId == specParams.RecipientId) && 
                (!specParams.DonatorId.HasValue || x.DonatorId == specParams.DonatorId) )
        {
            AddInclude(x => x.Product);
            AddInclude("Product.Store");
            AddInclude("Product.ProductType");                 

            AddInclude(x => x.Recipient);
            AddInclude(x => x.Donator);

            AddOrderBy(x => x.TokenName);
            ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);
            if (!string.IsNullOrEmpty(specParams.Sort)){
                switch (specParams.Sort){
                    case "dateAsc":
                        AddOrderBy(p => p.DateCreated);
                        break;
                    case "dateDesc":
                        AddOrderByDescending(p => p.DateCreated);
                        break;
                    default:
                        AddOrderBy(n => n.TokenName);
                        break;                      
                }
            }            
        }

        public TokenWithLookupSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Product);
            AddInclude("Product.Store");
            AddInclude("Product.ProductType");

            AddInclude(x => x.Recipient);     
            AddInclude(x => x.Donator);       
        }        
    }
}
