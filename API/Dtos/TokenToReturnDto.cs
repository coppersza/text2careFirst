using System;
using Core.Entities;

namespace API.Dtos
{
    public class TokenToReturnDto
    {
        public int Id { get; set; }
        public string TokenUid { get; set; }   

        public string Donator{ get; set; }

        public string TokenName { get; set; }
        public string BuyerEmail { get; set; }

        public string StoreName{ get; set; }

        public string ProductTypeName{ get; set; }      

        public string ProductName{ get; set; }

        public string Recipient{ get; set; }      

        public decimal CostPrice { get; set; }
        public decimal SalesPrice { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateStoreAssigned { get; set; }
        public DateTime DateAssigned { get; set; }
        public DateTime DateCollected { get; set; }
        public DateTime DateRelease { get; set; }
        public DateTime DateExpire { get; set; }
        public bool FoodCollected { get; set; }
        public bool Valid { get; set; }
        public string ImageUrl { get; set; }
        public string ShortUrl { get; set; }
        public string RecipientName { get; set; }
        public string DonatorName { get; set; }        
    }
}
