using System;
using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces
{
    public interface ITokenService
    {
        Task<Token> CreateOrUpdateTokenAsync(int tokenId, string tokenName, int productId, string buyerEmail);
        Task<IReadOnlyList<Token>> GetTokensForUserAsync(string buyerEmail);
        Task<IReadOnlyList<Token>> GetTokensForUserAsync(string buyerEmail, TokenSpecParams specParams);
        Task<int> GetTokensForUserCountAsync(string buyerEmail, TokenSpecParams specParams);
        Task<Token> GetTokenByIdAsync(int id, string buyerEmail);  
    }
}
