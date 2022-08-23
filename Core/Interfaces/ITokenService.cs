using System;
using Core.Entities;

namespace Core.Interfaces
{
    public interface ITokenService
    {
        Task<Token> CreateTokenAsync(string buyerEmail, string tokenName, int productId);
        Task<IReadOnlyList<Token>> GetTokensForUserAsync(string buyerEmail);
        Task<Token> GetTokenByIdAsync(int id, string buyerEmail);  
    }
}
