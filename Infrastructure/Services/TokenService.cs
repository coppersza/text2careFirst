using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.Identity;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TokenService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Token> CreateOrUpdateTokenAsync(int tokenId, string tokenName, int productId, string buyerEmail)
        {            
            var product = await _unitOfWork.Repository<Product>().GetByIdAsync(productId);
            var token = await _unitOfWork.Repository<Token>().GetByIdAsync(tokenId);
            
            var spec = new DonatorWithCountrySpecification(buyerEmail);
            var donator = await _unitOfWork.Repository<Donator>().GetEntityWithSpec(spec);
            var donatorUid = Guid.Empty.ToString().ToUpper();
            if (donator != null)
                donatorUid = donator.DonatorUid;

            if (token == null){
                var tokenUid = Guid.NewGuid().ToString().ToUpper(); 
                token = new Token(tokenUid, tokenName, buyerEmail, donatorUid, product);
                _unitOfWork.Repository<Token>().Add(token);
                //save to db                             
            }else{
                token.TokenName = tokenName;
                token.ProductId = productId;
                if (donator != null)
                    token.DonatorUid = donatorUid;
                _unitOfWork.Repository<Token>().Update(token);
            }
            var result = await _unitOfWork.Complete();   
            if (result <= 0) return null;
            return token; 
        }

        public async Task<IReadOnlyList<Token>> GetTokensForUserAsync(string buyerEmail)
        {                       
            var spec = new TokenWithLookupSpecification(buyerEmail);
            return await _unitOfWork.Repository<Token>().ListAsync(spec);
        }

        public async Task<IReadOnlyList<Token>> GetTokensForUserAsync(string buyerEmail, TokenSpecParams specParams)
        {
            var spec = new TokenWithLookupSpecification(buyerEmail, specParams);
            var countSpec = new TokenWithLookupSpecificationCount(buyerEmail, specParams);
            var data = await _unitOfWork.Repository<Token>().ListAsync(spec);
            return data;        
        }
        public async Task<int> GetTokensForUserCountAsync(string buyerEmail, TokenSpecParams specParams)
        {
            var countSpec = new TokenWithLookupSpecificationCount(buyerEmail, specParams);
            var totalItems = await _unitOfWork.Repository<Token>().CountAsync(countSpec);
            return totalItems;        
        }        

        public async Task<Token> GetTokenByIdAsync(int id, string buyerEmail)
        {
            var spec = new TokenWithLookupSpecification(id, buyerEmail);
            return await _unitOfWork.Repository<Token>().GetEntityWithSpec(spec);
        }
    }
}
