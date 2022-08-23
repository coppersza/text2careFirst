using System;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Services
{
    public class TokenService : ITokenService
    {

        private readonly IGenericRepository<Token> _tokenRepo;
        private readonly IGenericRepository<Product> _productRepo;
        

        public TokenService(IGenericRepository<Token> tokenRepo,
                            IGenericRepository<Product> productRepo)
        {
            _tokenRepo = tokenRepo;
            _productRepo = productRepo;
        }

        public async Task<Token> CreateTokenAsync(string buyerEmail, string tokenName, int productId)
        {
            var tokenUid = Guid.NewGuid().ToString(); 
            var salesPrice = 0;     
            var product = await _productRepo.GetByIdAsync(productId);

            //create order
            var token = new Token(tokenUid, tokenName, buyerEmail, product, salesPrice, product.Price);

            // _unitOfWork.Repository<Token>().Add(token);
            // //save to db
            // var result = await _unitOfWork.Complete();
            // if (result <= 0) return null;
            
            //return the order
            return token; 
        }

        Task<Token> ITokenService.GetTokenByIdAsync(int id, string buyerEmail)
        {
            throw new NotImplementedException();
        }

        Task<IReadOnlyList<Token>> ITokenService.GetTokensForUserAsync(string buyerEmail)
        {
            throw new NotImplementedException();
        }
    }
}
