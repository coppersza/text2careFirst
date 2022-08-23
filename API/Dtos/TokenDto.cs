using System;
using Core.Entities;

namespace API.Dtos
{
    public class TokenDto
    {        
        public int Id { get; set; }
        public string TokenUid { get; set; }  
        public string TokenName { get; set; } 
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }

    }
}
