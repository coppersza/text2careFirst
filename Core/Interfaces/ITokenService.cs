using System;
using Core.Entities;

namespace Core.Interfaces
{
    public interface ITokenService
    {
        Task<Token> CreateTokenAsync(string buyerEmail, Store store, ProductType productType, Product product);
        Task<IReadOnlyList<Token>> GetTokensForUserAsync(string buyerEmail);
        Task<Token> GetTokenByIdAsync(int id, string buyerEmail);  
    }
}
