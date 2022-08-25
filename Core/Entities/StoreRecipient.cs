using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class StoreRecipient : BaseEntity
    {
        [Column(TypeName = "char(38)")]
        [StringLength(38)]
        public string StoreRecipientUid { get; set; }

        [Column(TypeName = "char(38)")]
        [StringLength(38)]
        public string StoreUid { get; set; } 
        public int StoreId { get; set; }   

        [Column(TypeName = "char(38)")]
        [StringLength(38)]
        public string RecipientUid { get; set; }    
        public int RecipientId { get; set; }   

        [Column(TypeName = "char(38)")]
        [StringLength(38)]
        public string EmployeeUid { get; set; } 
        public int EmployeeId { get; set; }    
        public DateTime DateRegistered { get; set; } = DateTime.UtcNow;
        public Recipient Recipient{ get; set; }    
        public Store Store{ get; set; }
    }
}