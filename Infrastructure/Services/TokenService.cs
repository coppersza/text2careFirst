using System;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TokenService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Token> CreateTokenAsync(string buyerEmail, Store store, ProductType productType, Product product)
        {
            var tokenUid = Guid.NewGuid().ToString(); 
            var tokenName = "Test";
            var salesPrice = 0;
            var costPrice = 0;          

            //create order
            var token = new Token(tokenUid, tokenName, buyerEmail, store, productType, product, salesPrice, costPrice);

            _unitOfWork.Repository<Token>().Add(token);
            //save to db
            var result = await _unitOfWork.Complete();
            if (result <= 0) return null;
            
            //return the order
            return token;
        }

        public Task<Token> GetTokenByIdAsync(int id, string buyerEmail)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Token>> GetTokensForUserAsync(string buyerEmail)
        {
            throw new NotImplementedException();
        }
    }
}
