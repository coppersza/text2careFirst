using System;

namespace API.Dtos
{
    public class StoreToReturnDto
    {
        public int Id { get; set; }
        public string StoreName { get; set; }
        public string Description { get; set; } 
        public string ImageUrl { get; set; }        
        public string Country{ get; set; }
    }
}
