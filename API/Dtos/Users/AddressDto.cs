using System;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos.Users
{
    public class AddressDto
    {        
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public String Street { get; set; }
        [Required]
        public String City { get; set; }
        
        public string State { get; set; }
        
        public string ZipCode { get; set; }
        
    }
}
