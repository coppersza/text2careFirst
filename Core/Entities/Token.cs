using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Token : BaseEntity
    {
        public Token()
        {
        }

        public Token(string tokenUid, string tokenName, 
            string buyerEmail,             
            Product product)
        {
            TokenUid = tokenUid;
            TokenName = tokenName;
            BuyerEmail = buyerEmail;    
            Product = product;
            ProductId = product.Id;
            StoreId = product.StoreId;
            StoreUid = product.StoreUid;            
            RecipientId = 1;
            RecipientUid = "00000000-0000-0000-0000-000000000000";
            DonatorId = 1;
            DonatorUid = "00000000-0000-0000-0000-000000000000";
            CostPrice = product.Price;
            SalesPrice = 0;
            ImageUrl = "images/tokens/hourglass.png";
        }

        [Column(TypeName = "char(38)")]
        [StringLength(38)]
        public string TokenUid { get; set; }   
        public string TokenName { get; set; }

        [Column(TypeName = "char(38)")]
        [StringLength(38)]
        public string DonatorUid { get; set; }
        public int DonatorId { get; set; }
        public Donator Donator{ get; set; }
        public string BuyerEmail { get; set; }
        // public User User{ get; set; }     //TO DO   
        

        [Column(TypeName = "char(38)")]
        [StringLength(38)]
        public string StoreUid { get; set; }
        public int StoreId { get; set; }   
        public Store Store{ get; set; }
        // public int ProductTypeId { get; set; }  
        // public ProductType ProductType{ get; set; }              
        public int ProductId { get; set; }  
        public Product Product{ get; set; }               

        [Column(TypeName = "char(38)")]
        [StringLength(38)]
        public string StoreMealUid { get; set; } 

        [Column(TypeName = "char(38)")]
        [StringLength(38)]
        public string RecipientUid { get; set; }
        public int RecipientId { get; set; }
        public Recipient Recipient{ get; set; }

        public decimal CostPrice { get; set; }
        public decimal SalesPrice { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime DateStoreAssigned { get; set; } = DateTime.MinValue;
        public DateTime DateAssigned { get; set; } = DateTime.MinValue;
        public DateTime DateCollected { get; set; } = DateTime.MinValue;
        public DateTime DateRelease { get; set; } = DateTime.UtcNow;
        public DateTime DateExpire { get; set; } = DateTime.UtcNow.AddDays(60) ;
        public bool FoodCollected { get; set; } = false;
        public bool Valid { get; set; } = true;
        public string ImageUrl { get; set; }
        public string ShortUrl { get; set; }
        public string RecipientName { get; set; }
        public string DonatorName { get; set; }

    }
}
