using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class ApplicationUserStores : BaseEntity
    {
        [Column(TypeName = "char(38)")]
        [StringLength(38)]
        public string ApplicationUserStoreUid { get; set; }     
           
        [Column(TypeName = "char(38)")]
        [StringLength(38)]
        public string ApplicationUserId { get; set; }

        [Column(TypeName = "char(38)")]
        [StringLength(38)]
        public string StoreUid { get; set; }   
        public int StoreId { get; set; }                        
    }
}
