using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Store : BaseEntity
    {
        [Column(TypeName = "char(38)")]
        [StringLength(38)]
        public string StoreUid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public string PictureUrl { get; set; }       
    }
}