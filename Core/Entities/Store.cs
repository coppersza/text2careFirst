using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Store : BaseEntity
    {
        [Column(TypeName = "char(38)")]
        [StringLength(38)]
        public string StoreUid { get; set; }
        public string StoreName { get; set; }
        public string Description { get; set; } 
        public string ImageUrl { get; set; }        
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string FullName { get; set; }
        public string Nickname { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string DefaultToken { get; set; }
        public string PortalUser { get; set; }
        public string PortalPassword { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}