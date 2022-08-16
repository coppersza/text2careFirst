using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Product : BaseEntity
    {
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // [Key]        
        
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public ProductType ProductType{ get; set; }
        public int ProductTypeId { get; set; }
        public Store Store{ get; set; }
        public int StoreId { get; set; }        

        [Column(TypeName = "char(38)")]
        [StringLength(38)]
        public string StoreUid { get; set; }
        public bool IsActive { get; set; }
    }
}
