using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Token : BaseEntity
    {
        [Column(TypeName = "char(38)")]
        [StringLength(38)]
        public string TokenUid { get; set; }   

        [Column(TypeName = "char(38)")]
        [StringLength(38)]
        public string DonatorUid { get; set; }
        public int DonatorId { get; set; }
        public Donator Donator{ get; set; }
        public int UserId { get; set; }
        // public User User{ get; set; }     //TO DO   
        public string TokenName { get; set; }

        [Column(TypeName = "char(38)")]
        [StringLength(38)]
        public string StoreUid { get; set; }
        public int StoreId { get; set; }   
        public Store Store{ get; set; }
        public int ProductTypeId { get; set; }  
        public ProductType ProductType{ get; set; }              

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
